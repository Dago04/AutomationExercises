using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercises.Base
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected ExtentTest extentTest;

        public BasePage(IWebDriver driver, ExtentTest test)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            this.extentTest = test;
        }

        // Método para esperar a que un elemento sea visible
        protected IWebElement WaitForElementVisible(By locator)
        {
            try {
                extentTest.Log(Status.Info, $"Esperando que el elemento sea visible: {locator}");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch(WebDriverTimeoutException ex)
            {
                throw new NoSuchElementException($"Elemento con locator {locator} no se encontró. Detalles: {ex.Message}");
            }
            
        }

        protected IWebElement WaitForElementClickable(By locator)
        {
            try {

                extentTest.Log(Status.Info, $"Esperando que el elemento sea clickable: {locator}");
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NoSuchElementException($"Elemento con locator {locator} no se encontró. Detalles: {ex.Message}");
            }
            
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

        //Metodo para seleccionar un elemento select por el texto visible
        protected void SelectByVisibleText(By locator, string text)
        {
            var selectElement = new SelectElement(WaitForElementVisible(locator));
            selectElement.SelectByText(text);
        }
    }
}
