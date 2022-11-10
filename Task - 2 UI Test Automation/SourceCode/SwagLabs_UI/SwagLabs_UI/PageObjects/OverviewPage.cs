using SwagLabs_UI.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs_UI.PageObjects
{
    public class OverviewPage
    {
        /// <summary>
        /// This is the method is used to over write the constructor.
        /// It used to initialize the Page factory.
        /// </summary>
        public OverviewPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Checkout: Overview']")]
        public IWebElement overviewPageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "finish")]
        public IWebElement finishBTN { get; set; }

        /// <summary>
        /// This method is used to verify the title of the Overview Page
        /// </summary>
        /// <return> Void </return>
        public void verifyOverviewPageTitle()
        {
            Assert.IsTrue(overviewPageTitle.Displayed);
        }
        /// <summary>
        /// This method is used to click on Finish button on the Overview page
        /// </summary>
        /// /// <return> Void </return>
        public void clicksOnFinishBTN()
        {
            finishBTN.Click();
        }
    }
}
