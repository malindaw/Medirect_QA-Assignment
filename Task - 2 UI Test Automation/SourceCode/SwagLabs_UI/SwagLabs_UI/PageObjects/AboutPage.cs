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
    public class AboutPage
    {
        public AboutPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='headerMainNav']/div/nav/div/a")]
        public IWebElement aboutPage { get; set; }


        /// <summary>
        /// This method is used to verify the title of the About page 
        /// </summary>
        /// <return> Void </return>
        public void verifyAboutPage()
        {
            Assert.IsTrue(aboutPage.Displayed);
        }
    }
}
