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
    
    public class CartPage
    {
        /// <summary>
        /// This is the method is used to over write the constructor.
        /// It used to initialize the Page factory.
        /// </summary>
        public CartPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Your Cart']")]
        public IWebElement ownCartPageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement checkoutBTN { get; set; }

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        public IWebElement productRemoveBTN { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cart_item_label']")]
        public IWebElement verifySelectProductInTheCart { get; set; }


        /// <summary>
        /// This method is used to verify the title of Cart page.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void verifyOwnCartPage()
        {
            Assert.IsTrue(ownCartPageTitle.Displayed);
        }
        /// <summary>
        /// Thid method id used to click on Checkout Button on the Cart page.
        /// </summary>
        /// <retutn>
        /// Void
        /// </retutn>
        public void clicksOnCheckOutBTN()
        {
            checkoutBTN.Click();
        }
        /*/// <summary>
        /// This method is used to verify the title of Information page.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void verifyInformationPage()
        {
            Assert.IsTrue(informationPageTitle.Displayed);
        }*/
        /// <summary>
        /// This method is used to click on Remove button of the product on Cart page.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void clicksOnProductRemoveBTN()
        {
            productRemoveBTN.Click();
        }
        /// <summary>
        /// This method is used to verify selected product has removed from the Product list on Cart page.
        /// </summary>
        public void verifySelectProductRemovedInCartPage()
        {
            try
            {
                Assert.IsFalse(verifySelectProductInTheCart.Displayed);
            }catch(NoSuchElementException e)
            {
                Assert.True(true);
            }
        }
    }
}
