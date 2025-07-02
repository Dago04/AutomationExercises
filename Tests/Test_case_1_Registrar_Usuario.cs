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
        [Retry(2)]
        [Category("Registrar_Usuario")]
        public void Registrar_Usuario()
        {
            extentTest = extent.CreateTest("Test case #1 Registrar_Usuario: Validar el registro de un nuevo usuario de manera correcta");
            try
            {
                HomePage homePage = new HomePage(driver, extentTest);
                SignUpPage signUpPage = new SignUpPage(driver, extentTest);
                AccountInformationPage accountInformationPage = new AccountInformationPage(driver, extentTest);

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

                //10. Select checkbox 'Sign up for our newsletter!'
                accountInformationPage.clickOnNewsletterCheckbox();

                //11. Select checkbox 'Receive special offers from our partners!'
                accountInformationPage.clickOnSpecialOffersCheckbox();

                //12. Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
                accountInformationPage.fillAddressInformation("QA", "Automation", "QA Company", "123 QA Street", "Suite 100", "United States", "California", "Los Angeles", "90001", "1234567890");

                //13. Click 'Create Account button'
                accountInformationPage.clickOnCreateAccountButton();

                //14. Verify that 'ACCOUNT CREATED!' is visible
                Assert.That(accountInformationPage.isAccountCreatedLabelVisible(), Is.True);
                extentTest.Log(Status.Pass, "Se valida que el texto 'ACCOUNT CREATED!' es visible");

                //15. Click 'Continue' button
                accountInformationPage.clickOnContinueButton();

                //16. Verify that 'Logged in as username' is visible
                Assert.That(homePage.isLoggedUserLabelVisible(), Is.True);
                extentTest.Log(Status.Pass, $"Se valida que el texto 'Logged in as username' es visible");

                //17. Click 'Delete Account' button
                homePage.clickOnDeleteAccountButton();

                //18. Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
                Assert.That(accountInformationPage.isAccountDeletedLabelVisible(), Is.True);
                extentTest.Log(Status.Pass, "Se valida que el texto 'ACCOUNT DELETED!' es visible");
            }
            catch (Exception ex)
            {
                extentTest.Log(Status.Fail, "La prueba falló: " + ex.Message);
                Assert.Fail(ex.Message);
            }
        }


    }
}
