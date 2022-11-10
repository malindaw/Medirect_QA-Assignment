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
    public class InformationPage
    {
        
        /// <summary>
        /// This is the method is used to over write the constructor.
        /// It used to initialize the Page factory.
        /// </summary>
        public InformationPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement firstNameInfo { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement lastNameInfo { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement postalCodeInfo { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement continueBTN { get; set; }

        [FindsBy(How = How.XPath, Using = "//h3[text()='Error: First Name is required']")]
        public IWebElement infoValidateMSG { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='input_error form_input error']")]
        public IWebElement infoValidateCrossMark { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Checkout: Your Information']")]
        public IWebElement informationPageTitle { get; set; }

        /// <summary>
        /// This method is used to enter values and fill the form
        /// Firstname, Laset name, and Postal code are the parameters need
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="lname"></param>
        /// <param name="pcode"></param>
        /// <return> Void </return>
        public void fillingInformation(string fname, string lname, int pcode)
        {
            firstNameInfo.SendKeys(fname);
            lastNameInfo.SendKeys(lname);
            postalCodeInfo.SendKeys(pcode.ToString());
        }
        /// <summary>
        /// This method is used to click on Continue button on the Information Page
        /// </summary>
        ///   /// <return> Void </return>
        public void clicksOnContinueBTN()
        {
            continueBTN.Click();
        }
        /// <summary>
        ///  This method is used to verify the Validation message on the Information Page
        /// </summary>
        public void verifyInfoValidateMSG()
        {
            Assert.IsTrue(infoValidateMSG.Displayed);
            Assert.IsTrue(infoValidateCrossMark.Displayed);

        }
        /// <summary>
        /// This method is used to verify the title of Information page.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void verifyInformationPage()
        {
            Assert.IsTrue(informationPageTitle.Displayed);
        }

    }

}
