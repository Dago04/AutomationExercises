using AutomationExercises.Base;
using AutomationExercises.PageObjects;
using AventStack.ExtentReports;

namespace AutomationExercises.Tests
{
    public class Test_case_1_Registrar_Usuario : BaseTest
    {

        public Test_case_1_Registrar_Usuario() : base("Test_case_1_Registrar_Usuario.html")
        {
        }

        [Test]
        [Retry(1)]
        [Category("Registrar_Usuario")]
        public void Registrar_Usuario()
        {
            extentTest = extent.CreateTest("Test case #1 Registrar_Usuario: Validar el registro de un nuevo usuario de manera correcta");
            try
            {
                HomePage homePage = new HomePage(driver);

                homePage.goToHomePage();

                Assert.That(homePage.getHomeURL(), Is.EqualTo("https://automationexercise.com/"));
                extentTest.Log(Status.Pass, $"Se valida correctamente la url de la página {homePage.getHomeURL()}");


            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, "La prueba falló: " + ex.Message);
                Assert.Fail(ex.Message);
            }
        }


    }
}
