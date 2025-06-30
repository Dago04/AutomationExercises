using AutomationExercises.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercises.PageObjects
{
    public class AccountInformationPage :BasePage
    {
        public AccountInformationPage(IWebDriver driver) : base(driver)
        {

        }

        //selectores

        By lblAccountInformation = By.XPath("//div[@class='login-form']/h2/b");
        By checkboxMr = By.XPath("//label[@for='id_gender1']/div");
        By checkboxMrs = By.XPath("//label[@for='id_gender2']/div");
        By txtPassword = By.XPath("//input[@data-qa='password']");
        By selectDays = By.XPath("//select[@data-qa='days']");
        By selectMonths = By.XPath("//select[@data-qa='months']");
        By selectYears = By.XPath("//select[@data-qa='years']");

        //Métodos
        public bool isAccountInformationLabelVisible()
        {
            return IsElementVisible(lblAccountInformation);
        }

        public void clickOnMrCheckbox()
        {
            Click(checkboxMr);
        }

        public void clickOnMrsCheckbox()
        {
            Click(checkboxMrs);
        }
        public void enterPassword(string password)
        {
            EnterText(txtPassword, password);
        }

        public void selectDay(string day)
        {
            SelectByVisibleText(selectDays, day);
        }
        public void selectMonth(string month)
        {
            SelectByVisibleText(selectMonths, month);
        }
        public void selectYear(string year)
        {
            SelectByVisibleText(selectYears, year);
        }

        public void fillAccountInformation(string password, string day, string month, string year) {
            clickOnMrCheckbox();
            enterPassword(password);
            selectDay(day);
            selectMonth(month);
            selectYear(year);
        }
    }
}
