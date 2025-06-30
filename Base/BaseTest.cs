
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using AventStack.ExtentReports.Model;
using AutomationExercises.Drivers;
using System.Reactive;

namespace AutomationExercises.Base
{
    public class    BaseTest
    {
        protected IWebDriver driver;
        protected static ExtentReports extent;
        protected ExtentTest extentTest;
        protected string reportTestPage = "";
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        public BaseTest(string pageContext)
        {
            this.reportTestPage = pageContext;
        }

        [OneTimeSetUp]
        public void SetUpReporter() {


            // Definir la ruta donde se generará el reporte
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string reportDirectory = Path.Combine(projectRoot, "Reportes");

            // Verifica si la carpeta `reports` existe, si no, la crea
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }

            string reportPath = Path.Combine(reportDirectory, $"{timestamp}_{reportTestPage}");

            // Inicializar ExtentSparkReporter
            var sparkReporter = new ExtentSparkReporter(reportPath);

            // Configurar el nombre del reporte y el título del documento
            sparkReporter.Config.ReportName = "Web Automation Results";
            sparkReporter.Config.DocumentTitle = "Test Results";

            // Crear instancia de ExtentReports y agregar el reporter
            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);

            // Agregar información adicional sobre el sistema o el tester
            extent.AddSystemInfo("Tester", "Dago");
        }

        [SetUp]
        public void Setup()
        {
          
            driver = WebDriverFactory.CreateDriver();

        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {

                // Crear carpeta para screenshots
                var screenshotDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Reportes", "Screenshots");
                Directory.CreateDirectory(screenshotDir);

                var screenshotPath = Path.Combine(screenshotDir, $"{timestamp}_{TestContext.CurrentContext.Test.Name}" + ".png");

                // Tomar screenshot y guardar
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);

                // Agregar información al reporte
                extentTest.AddScreenCaptureFromPath(screenshotPath);
                extentTest.Fail(stacktrace);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                extentTest.Pass("Test passed");
            }
            else
            {
                extentTest.Skip("Test skipped");
            }

            // Cerrar navegador
            driver.Close();
            driver.Quit();

        }

        [OneTimeTearDown]
        public void EndReport()
        {
            // Escribir y cerrar reporte
            extent.Flush();
        }
    }
}
