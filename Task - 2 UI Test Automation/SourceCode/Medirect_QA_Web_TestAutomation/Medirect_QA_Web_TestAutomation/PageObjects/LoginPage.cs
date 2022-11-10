using Medirect_QA_Web_TestAutomation.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medirect_QA_Web_TestAutomation.PageObjects
{
    public class LoginPage
    {
        /// <summary>
        /// This is the method is used to over write the constructor.
        /// It used to initialize the Page factory.
        /// </summary>
        public LoginPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }


        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement loginBTN { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[text()='Epic sadface: Sorry, this user has been locked out.']")]
        public IWebElement lockedUserERR { get; set; }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement mainMenuOPT { get; set; }

       

        [FindsBy(How = How.XPath, Using = "//h3[text()='Epic sadface: Username is required']")]
        public IWebElement loginCredentialsValidate { get; set; }



        /// <summary>
        /// This method is used to enter the login credientials. 
        /// Username and Password are the parameters needed.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <return> Void </return>
        public void addloginCredentials(string userName, string passWord)
        {
            username.SendKeys(userName);
            password.SendKeys(passWord);
        }
        /// <summary>
        /// This method is used to click on Login button
        /// </summary>
        /// <return> Void </return>
        public void clickLoginBtn()
        {
            loginBTN.Click();
        }
        /// <summary>
        /// This method is used to verify that Error message for the locked user on Login Page
        /// </summary>
        /// <return> Void </return>
        public void verifyLockedUserError()
        {
            Assert.IsTrue(lockedUserERR.Displayed);
        }
        /// <summary>
        /// This method is used to  click on Main Menu button
        /// </summary>
        /// <return> Void </return>
        public void clickMainMenuOPT()
        {
            mainMenuOPT.Click();
        }
        /// <summary>
        /// This method is used to verify that Login button is displays on the Login Page
        /// </summary>
        /// <return> Void </return>
        public void verifyLoginBTN()
        {
            Assert.IsTrue(loginBTN.Displayed);
        }
        /// <summary>
        /// This method is used to verify that Error message and the red colour cross for empty login scenario.
        /// </summary>
        /// <return> Void</return>
        public void verifyLoginCredentials()
        {
            Assert.IsTrue(loginCredentialsValidate.Displayed); 
            for (int i = 1; i < 3; i++)
            {
                
                Assert.AreEqual("input_error form_input error", BaseTest.driver.FindElement(By.XPath("//div[@class='login-box']/form/div[" + i + "]/input")).GetAttribute("class"));
            }

        }
    }
}
