using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercises.Base
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Método para esperar a que un elemento sea visible
        protected IWebElement WaitForElementVisible(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }

        // Método para hacer clic en un elemento
        protected void Click(By locator)
        {
            WaitForElementVisible(locator);
            WaitForElementClickable(locator).Click();
        }

        // Método para escribir texto en un campo
        protected void EnterText(By locator, string text)
        {
            var element = WaitForElementVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        // Método para obtener texto de un elemento
        protected string GetText(By locator)
        {
            return WaitForElementVisible(locator).Text;
        }

        // Método para validar si un elemento está visible
        protected bool IsElementVisible(By locator)
        {
            try
            {
                return WaitForElementVisible(locator).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
