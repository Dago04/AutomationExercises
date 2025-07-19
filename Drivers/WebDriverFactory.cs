using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AutomationExercises.Drivers
{
    public class WebDriverFactory
    {

        public static IWebDriver CreateDriver(bool headless = false) { 
        

            ChromeOptions options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--no-sandbox"); // importante en entornos CI
                options.AddArgument("--window-size=1920,1080");
            }

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;

        }
    }
}
