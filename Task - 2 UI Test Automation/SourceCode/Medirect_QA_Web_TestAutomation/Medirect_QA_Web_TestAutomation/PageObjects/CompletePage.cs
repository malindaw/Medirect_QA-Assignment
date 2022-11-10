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
    public class CompletePage
    {
        /// <summary>
        /// This is the method is used to over write the constructor.
        /// It used to initialize the Page factory.
        /// </summary>
        public CompletePage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//span[text()='Checkout: Complete!']")]
        public IWebElement completePageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Your order has been dispatched, and will arrive just as fast as the pony can get there!']")]
        public IWebElement dispatchMSG { get; set; }

        /// <summary>
        /// This method is used to verify the title of the Complete page.
        /// </summary>
        /// <return>
        /// Void 
        /// </return>
        public void verifyCompletePageTitle()
        {
            Assert.IsTrue(completePageTitle.Displayed);
        }
        /// <summary>
        /// This method is used to verify the title of the Dispatch message on the Complete page.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void verifyCompletePageDispatchMSG()
        {
            Assert.IsTrue(dispatchMSG.Displayed);
        }
    }
}
