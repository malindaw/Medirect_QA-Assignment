using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Medirect_QA_Web_TestAutomation.Drivers;
using Medirect_QA_Web_TestAutomation.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace Medirect_QA_Web_TestAutomation.StepDefinitions
{
    [Binding]
    public class loginSD
    {
        LoginPage loginPO;
        BaseTest baseTestPO = new BaseTest();
        
        [Given(@"user in the login page")]
        public void GivenUserInTheLoginPage()
        {  
            baseTestPO.BrowserSetup();           
            loginPO = new LoginPage();
           
        }
        [When(@"user enter username and password")]
        public void WhenUserEnterUsernameAndPassword(Table table)
        {           
            dynamic data = table.CreateDynamicInstance();
            loginPO.addloginCredentials((string)data.Username, (string)data.Password);
           
        }
        [When(@"user clicks on the login button")]
        public void WhenUserClicksOnTheLoginButton()
        {
            loginPO.clickLoginBtn();
        }

        [Then(@"user will get error message")]
        public void ThenUserWillGetErrorMessage()
        {
            loginPO.verifyLockedUserError();
        }

        [When(@"user clicks on main menu")]
        public void WhenUserClicksOnMainMenu()
        {
            loginPO.clickMainMenuOPT();
        }

        /*[When(@"user clicks on the logout option")]
        public void WhenUserClicksOnTheLogoutOption()
        {
            loginPO.clicklogoutOPT();
        }*/

        [Then(@"user will navigate to login page")]
        public void ThenUserWillNavigateToLoginPage()
        {
            loginPO.verifyLoginBTN();
        }

        [Then(@"user credentials are validate")]
        public void ThenUserCredentialsAreValidate()
        {
            loginPO.verifyLoginCredentials();
        }

    }
}
