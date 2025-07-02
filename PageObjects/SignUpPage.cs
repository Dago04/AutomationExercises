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
        public SignUpPage(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {

        }

        //Selectores
        By lblNewUser = By.XPath("//div[@class='signup-form']/h2");
        By txtName = By.XPath("//form[@action='/signup']/input[@data-qa='signup-name']");
        By txtEmail = By.XPath("//form[@action='/signup']/input[@data-qa='signup-email']");
        By btnSubmit = By.XPath("//form[@action='/signup']/button[@data-qa='signup-button']");


        //Métodos

        public bool isNewUserLabelVisible()
        {
            return IsElementVisible(lblNewUser);
        }

        public void registerUser(string name, string email) {
            EnterText(txtName, name);
            EnterText(txtEmail, email);
            Click(btnSubmit);
        }

    }
}
