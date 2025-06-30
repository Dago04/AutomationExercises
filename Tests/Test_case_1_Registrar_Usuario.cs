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
                SignUpPage signUpPage = new SignUpPage(driver);
                AccountInformationPage accountInformationPage = new AccountInformationPage(driver);

                //1. Launch browser
                //2. Navigate to url 'http://automationexercise.com'
                homePage.goToHomePage();

                //3. Verify that home page is visible successfully
                Assert.That(homePage.getHomeURL(), Is.EqualTo("https://automationexercise.com/"));
                extentTest.Log(Status.Pass, $"Se valida correctamente la url de la página {homePage.getHomeURL()}");

                //4. Click on 'Signup / Login' button
                homePage.clickOnSignupLoginLink();

                //5. Verify 'New User Signup!' is visible
                Assert.That(signUpPage.isNewUserLabelVisible(), Is.True);
                extentTest.Log(Status.Pass, "Se valida que el texto 'New User Signup!' es visible");

                //6. Enter name and email address
                //7. Click 'Signup' button
                signUpPage.registerUser("pruebaQA", "pruebaQA@gmail.com");

                //8. Verify that 'ENTER ACCOUNT INFORMATION' is visible
                Assert.That(accountInformationPage.isAccountInformationLabelVisible(), Is.True);
                extentTest.Log(Status.Pass, "Se valida que el texto 'ENTER ACCOUNT INFORMATION' es visible");

                //9. Fill details: Title, Name, Email, Password, Date of birth
                accountInformationPage.fillAccountInformation("12345", "4", "April", "2021");

            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, "La prueba falló: " + ex.Message);
                Assert.Fail(ex.Message);
            }
        }


    }
}
