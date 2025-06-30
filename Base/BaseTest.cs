
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using AventStack.ExtentReports.Model;
using AutomationExercises.Drivers;

namespace AutomationExercises.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected static ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void SetUpReporter() {

            // Directorio para el reporte
            var dir = TestContext.CurrentContext.WorkDirectory;
            var reportPath = Path.Combine(dir, "Reports", "TestReport.html");

            // Crear carpeta Reports si no existe
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

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

            // Crear test ExtentReports con el nombre del test actual
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
                var screenshotDir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "Reports", "Screenshots");
                Directory.CreateDirectory(screenshotDir);

                var screenshotPath = Path.Combine(screenshotDir, TestContext.CurrentContext.Test.Name + ".png");

                // Tomar screenshot y guardar
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);

                // Agregar información al reporte
                test.Fail("Test failed");
                test.AddScreenCaptureFromPath(screenshotPath);
                test.Fail(errorMessage);
                test.Fail(stacktrace);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("Test passed");
            }
            else
            {
                test.Skip("Test skipped");
            }

            // Cerrar navegador
            driver.Quit();
            driver.Close();

        }

        [OneTimeTearDown]
        public void EndReport+()
        {
            // Escribir y cerrar reporte
            extent.Flush();
        }
    }
}
