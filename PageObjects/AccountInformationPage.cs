using AutomationExercises.Base;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercises.PageObjects
{
    public class AccountInformationPage : BasePage
    {
        public AccountInformationPage(IWebDriver driver) : base(driver)
        {

        }

        //selectores


        //Account Information

        private By lblAccountInformation = By.XPath("//div[@class='login-form']/h2/b");
        private By checkboxMr = By.XPath("//label[@for='id_gender1']/div");
        private By checkboxMrs = By.XPath("//label[@for='id_gender2']/div");
        private By txtPassword = By.XPath("//input[@data-qa='password']");
        private By selectDays = By.XPath("//select[@data-qa='days']");
        private By selectMonths = By.XPath("//select[@data-qa='months']");
        private By selectYears = By.XPath("//select[@data-qa='years']");
        private By checkboxNewsletter = By.XPath("//input[@type='checkbox' and contains(@id, 'newsletter')]");
        private By checkboxSpecialOffers = By.XPath("//input[@type='checkbox' and contains(@id, 'optin')]");

        //Address Information
        private By txtFirstName = By.XPath("//input[@type='text' and contains(@id, 'first_name')]");
        private By txtLastName = By.XPath("//input[@type='text' and contains(@id, 'last_name')]");
        private By txtCompany = By.XPath("//input[@type='text' and contains(@id, 'company')]");
        private By txtAddress1 = By.XPath("//input[@type='text' and contains(@id, 'address1')]");
        private By txtAddress2 = By.XPath("//input[@type='text' and contains(@id, 'address2')]");
        private By selectCountry = By.XPath("//select[@data-qa='country']");
        private By txtState = By.XPath("//input[@type='text' and contains(@id, 'state')]");
        private By txtCity = By.XPath("//input[@type='text' and contains(@id, 'city')]");
        private By txtZipcode = By.XPath("//input[@type='text' and contains(@id, 'zipcode')]");
        private By txtMobileNumber = By.XPath("//input[@type='text' and contains(@id, 'mobile_number')]");
        private By btnCreateAccount = By.XPath("//button[@data-qa='create-account']");

        //Account create information 

        private By lblAccountCreated = By.XPath("//h2[@data-qa='account-created']");
        private By lblAccountDeleted = By.XPath("//h2[@data-qa='account-deleted']");
        private By btnContinue = By.XPath("//a[@data-qa='continue-button']");

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

        public void fillAccountInformation(string password, string day, string month, string year)
        {
            clickOnMrCheckbox();
            EnterText(txtPassword, password);
            selectDay(day);
            selectMonth(month);
            selectYear(year);
        }

        public void clickOnNewsletterCheckbox()
        {
            Click(checkboxNewsletter);
        }
        public void clickOnSpecialOffersCheckbox()
        {
            Click(checkboxSpecialOffers);
        }

        public void fillAddressInformation(string firstName, string lastName, string company, string address1, string address2, string country, string state, string city, string zipcode, string mobileNumber)
        {
            EnterText(txtFirstName, firstName);
            EnterText(txtLastName, lastName);
            EnterText(txtCompany, company);
            EnterText(txtAddress1, address1);
            EnterText(txtAddress2, address2);
            SelectByVisibleText(selectCountry, country);
            EnterText(txtState, state);
            EnterText(txtCity, city);
            EnterText(txtZipcode, zipcode);
            EnterText(txtMobileNumber, mobileNumber);
        }
        public void clickOnCreateAccountButton()
        {
            Click(btnCreateAccount);
        }
        public bool isAccountCreatedLabelVisible()
        {
            return IsElementVisible(lblAccountCreated);
        }
        public bool isAccountDeletedLabelVisible()
        {
            return IsElementVisible(lblAccountDeleted);
        }
        public void clickOnContinueButton()
        {
            Click(btnContinue);
        }

    }
}
