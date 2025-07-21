using AutomationExercises.Base;
using AutomationExercises.PageObjects;
using AventStack.ExtentReports;
using static AutomationExercises.Data.Utils.TestDataConfig;


namespace AutomationExercises.Tests
{
    class Test_Case_2_Login_Exitoso : BaseTest
    {
        public Test_Case_2_Login_Exitoso() : base("Test_Case_2_Login_Exitoso.html")
        {
        }

        [Test]
        [Retry(2)]
        [Category("Login_Exitoso")]
        public void Login_Exitoso() {
            extentTest = extent.CreateTest("Test case #2 Login_Exitoso: Validar que se pueda realizar un login con las credenciales correctas");

            try
            {
                HomePage homePage = new HomePage(driver);
                SignUpPage signUpPage = new SignUpPage(driver);
                AccountInformationPage accountInformationPage = new AccountInformationPage(driver);

                //1. Launch browser
                //2. Navigate to url 'http://automationexercise.com'
                homePage.goToHomePage();
                //3. Verify that home page is visible successfully
                Assert.That(homePage.isHomeIconVisible, Is.True, "El icono de home no se encuentra visible");
                extentTest.Log(Status.Pass, $"Se valida correctamente el icono de home page en el navbar de la página");
                //4. Click on 'Signup / Login' button
                homePage.clickOnSignupLoginLink();
                //5. Verify 'Login to your account' is visible
                Assert.That(signUpPage.isLoginToYourAccountLabelVisible(), Is.True, $"El titulo 'Login to your account' no es visible");
                extentTest.Log(Status.Pass, "Se valida que el texto 'New User Signup!' es visible");
                //6. Enter correct email address and password
                //7. Click 'login' button
                signUpPage.loginUser(Email,Password);
                //8. Verify that 'Logged in as username' is visible
                Assert.That(homePage.isLoggedUserLabelVisible(), Is.True, "El texto 'Logged in as username' no es visible");
                extentTest.Log(Status.Pass, "Se valida que el texto 'Logged in as username' es visible");
                //9. Click 'Delete Account' button
                homePage.clickOnDeleteAccountButton();
                //10. Verify that 'ACCOUNT DELETED!' is visible
                Assert.That(accountInformationPage.isAccountDeletedLabelVisible(), Is.True, "El texto 'ACCOUNT DELETED!' no es visible");
                extentTest.Log(Status.Pass, "Se valida que el texto 'ACCOUNT DELETED!' es visible");

            }
            catch (Exception ex) {
                extentTest.Log(Status.Fail, "La prueba falló: " + ex.Message);
                Assert.Fail(ex.Message);
            }
        }

    }
}
