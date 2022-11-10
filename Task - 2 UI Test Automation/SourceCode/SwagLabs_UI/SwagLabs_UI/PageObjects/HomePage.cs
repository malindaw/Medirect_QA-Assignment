using SwagLabs_UI.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs_UI.PageObjects
{
    public class HomePage
    {
        /// <summary>
        /// This is the method is used to over write the constructor.
        /// It used to initialize the Page factory.
        /// </summary>
        public HomePage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//span[text()='Products']")]
        public IWebElement productLBL { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        public IWebElement AddToCartBTN { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='1']")]
        public IWebElement AddToCartIcon1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='2']")]
        public IWebElement AddToCartIcon2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='/static/media/sl-404.168b1cce.jpg']")]
        public IWebElement problemProductIMG { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bike-light")]
        public IWebElement sauceLabsBikeLightAddToCartBTN { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class='product_sort_container']")]
        public IWebElement sortDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='inventory_container']/div/div/div[2]/div/a/div")]
        public IWebElement firstProduct { get; set; }

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        public IWebElement logoutOPT { get; set; }

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        public IWebElement aboutOPT { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='inventory_container']/div/div/div[2]/div[2]/div")]
        public IWebElement firstProtuctPrice { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//div[@id='inventory_container']/div/div[2]/div[2]/div[2]/div")]
        public IWebElement secondProtuctPrice { get; set; }

        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        public IWebElement cartIcon { get; set; }

        /// <summary>
        /// This method is used to verify the title of the Product page
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void verifyProductTitle()
        {
            Assert.IsTrue(productLBL.Displayed);
        }
        /// <summary>
        /// This method is used to click on Add to Cart button
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void clickonAddToCartBTN()
        {
            AddToCartBTN.Click();
        }
        /// <summary>
        /// This method is used to verify that Add to Cart icon is updating with the number of product added to cart
        /// This is verify the first number.
        /// </summary>
        /// <return>
        /// Void 
        /// </return>
        public void verifyAddToCartIcon1()
        {
            Assert.IsTrue(AddToCartIcon1.Displayed);
        }
        /// <summary>
        /// This method is used to verify that Add to Cart icon is updating with the number of product added to cart
        /// This is verify the second number.
        /// </summary>
        /// <return>
        /// Void 
        /// </return>
        public void verifyAddToCartIcon2()
        {
            Assert.IsTrue(AddToCartIcon2.Displayed);
        }
        /// <summary>
        /// This method is used to verify that product image is different for the problem user in Home page.
        /// </summary>
        /// <return>
        /// Void
        /// </return>

        public void verifyProblemUserIMG()
        {
            Assert.IsTrue(problemProductIMG.Displayed);
        }
        /// <summary>
        /// This method is used to click on Add to Cart icon in multiple times.
        /// </summary>
        /// <return> Void </return>
        public void clicksOnMultipleAddToCartBTN(string _prod)
        {
            var firstProtuctPriceValueH2L = int.Parse(_prod);

            for (int i = 1; i <= firstProtuctPriceValueH2L; i++)
            {
                BaseTest.driver.FindElement(By.XPath("//div[@class='inventory_list']/div[" + i + "]/div[2]/div[2]/button")).Click();
            }
        }
        /// <summary>
        /// This method is used to select the Sorting order in dropdown
        /// </summary>
        /// <param name="ZAValue"></param>
        /// <return> Void </return>
        public void selectSortDropDown(string ZAValue)
        {
            SelectElement sortOPT = new SelectElement(sortDropDown);
            sortOPT.SelectByText(ZAValue);
        }
        /// <summary>
        /// This method is used to verify the products are sorted as Z to A
        /// </summary>
        /*public void verifytSortProdcut()
        {
            Assert.AreEqual("Test.allTheThings() T-Shirt (Red)",firstProduct.Text); 
        }*/
        /// <summary>
        /// This method is used to verify the products are sorted in the given order.
        /// If the order value is Acending, verify the products are in Acending order.
        /// If the order value is Decending, verify the products are in Decending order.
        /// </summary>
        /// <param name="order"></param>
        /// <return> Void </return>
        public void verifySortProductOrder(string order)
        {
            
            switch (order)
            {
                case "decending":
                    Assert.AreEqual("Test.allTheThings() T-Shirt (Red)", firstProduct.Text);
                    break;
                case "ascending":
                    Assert.AreEqual("Sauce Labs Backpack", firstProduct.Text);
                    break;
                case "Price low to high":
                    Assert.AreEqual("Sauce Labs Onesie", firstProduct.Text);
                    
                    var firstProtuctPriceValue = float.Parse(firstProtuctPrice.Text.Substring(1, firstProtuctPrice.Text.Length - 1));
                    var secondProtuctPriceValue = float.Parse(secondProtuctPrice.Text.Substring(1, secondProtuctPrice.Text.Length - 1));
                    if (firstProtuctPriceValue < secondProtuctPriceValue)
                    {
                        Assert.True(true);
                    }
                    else
                        Assert.True(false);
                    break;
                case "Price high to low":
                    Assert.AreEqual("Sauce Labs Fleece Jacket", firstProduct.Text);
                    var firstProtuctPriceValueH2L = float.Parse(firstProtuctPrice.Text.Substring(1, firstProtuctPrice.Text.Length - 1));
                    var secondProtuctPriceValueH2L = float.Parse(secondProtuctPrice.Text.Substring(1, secondProtuctPrice.Text.Length - 1));
                    if (firstProtuctPriceValueH2L > secondProtuctPriceValueH2L)
                    {
                        Assert.True(true);
                    }
                    else
                        Assert.True(false);
                    break;

            }
        }
        /// <summary>
        /// This method is used to click on Main menu with the given value
        /// </summary>
        /// <param name="_menu"></param>
        /// <return> Void </return>
        public void clicksOnMainMenuOPT(string _menu)
        {

            switch (_menu)
            {
                case "LogOut":
                    logoutOPT.Click();
                   
                    break;
                case "About":
                    aboutOPT.Click();
                    break;      

            }
        }
        /// <summary>
        /// This method is used to click on Cart icon on top right corner.
        /// </summary>
        /// <return>
        /// Void
        /// </return>
        public void clicksOnCartIcon()
        {
            cartIcon.Click();
        }
    }
}
