using AutomationExercises.Base;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace AutomationExercises.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {

        }

        //Selectores

        private By signupLoginLink = By.XPath("//a[@href='/login']");
        private By homePageImg = By.XPath("//img[@alt='Website for automation practice']");
        private By lblLoggedUser = By.XPath("//ul[@class='nav navbar-nav']/li[last()]");
        private By btnDeleteAccount = By.XPath("//ul[@class='nav navbar-nav']/li/a[@href='/delete_account']");

        public void goToHomePage()
        {
            driver.Navigate().GoToUrl("https://automationexercise.com/");

            WaitForElementVisible(homePageImg);
        }
        public void clickOnSignupLoginLink()
        {
            Click(signupLoginLink);
        }

        public string getHomeURL()
        {
            return driver.Url;
        }

        public bool isLoggedUserLabelVisible()
        {
            return IsElementVisible(lblLoggedUser);
        }

        public void clickOnDeleteAccountButton()
        {
            Click(btnDeleteAccount);
        }
    }
}
