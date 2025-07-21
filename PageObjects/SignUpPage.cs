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
    public class SignUpPage :BasePage
    {
        public SignUpPage(IWebDriver driver) : base(driver)
        {

        }

        //Selectores
        By lblNewUser = By.XPath("//div[@class='signup-form']/h2");
        By lblLoginToYourAccount = By.XPath("//div[@class='login-form']/h2");
        By txtName = By.XPath("//form[@action='/signup']/input[@data-qa='signup-name']");
        By txtEmail = By.XPath("//form[@action='/signup']/input[@data-qa='signup-email']");
        By btnSubmit = By.XPath("//form[@action='/signup']/button[@data-qa='signup-button']");

        By txtLoginEmail = By.XPath("//form[@action='/login']/input[@data-qa='login-email']");
        By txtLoginPassword = By.XPath("//form[@action='/login']/input[@data-qa='login-password']");
        By btnLogin = By.XPath("//form[@action='/login']/button[@data-qa='login-button']");


        //Métodos

        public bool isNewUserLabelVisible()
        {
            return IsElementVisible(lblNewUser);
        }
        public bool isLoginToYourAccountLabelVisible()
        {
            return IsElementVisible(lblLoginToYourAccount);
        }

        public void registerUser(string name, string email) {
            EnterText(txtName, name);
            EnterText(txtEmail, email);
            Click(btnSubmit);
        }

        public void loginUser(string email, string password)
        {
            EnterText(txtLoginEmail, email);
            EnterText(txtLoginPassword, password);
            Click(btnLogin);
        }

    }
}
