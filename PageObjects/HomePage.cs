using AutomationExercises.Base;
using OpenQA.Selenium;

namespace AutomationExercises.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        //Selectores

        private By signupLoginLink = By.XPath("//a[@href='/login']");
        private By homePageImg = By.XPath("//img[@alt='Website for automation practice']");

        public void goToHomePage() { 
            driver.Navigate().GoToUrl("https://automationexercise.com/");

            WaitForElementVisible(homePageImg);
        }

        public string getHomeURL() { 
             return driver.Url;
        }
    }
}
