using Medirect_QA_Web_TestAutomation.Drivers;
using Medirect_QA_Web_TestAutomation.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medirect_QA_Web_TestAutomation.StepDefinitions
{
    [Binding]
    public class HomeSD
    {
        HomePage homePO = new HomePage();
        AboutPage aboutPO = new AboutPage();
        
        [Then(@"user navigate to home page")]
        public void ThenUserNavigateToHomePage()
        {            
            homePO.verifyProductTitle();
        }
        [When(@"user clicks on the selected product addToCart button")]
        public void WhenUserClicksOnTheSelectedProductAddToCartButton()
        {
            homePO.clickonAddToCartBTN();
              
        }
        [Then(@"user can see selected product add to the cart icon")]
        public void ThenUserCanSeeSelectedProductAddToTheCartIcon()
        {
            homePO.verifyAddToCartIcon1();
        }
        [Then(@"user cannot see appropriate product picture")]
        public void ThenUserCannotSeeAppropriateProductPicture()
        {
            homePO.verifyProblemUserIMG();
        }
        [When(@"user clicks on the multiple as ""([^""]*)"" selected product addToCart button")]
        public void WhenUserClicksOnTheMultipleAsSelectedProductAddToCartButton(string prod)
        {
            homePO.clicksOnMultipleAddToCartBTN(prod);
        }



        /*[When(@"user clicks on the multiple selected product addToCart button")]
        public void WhenUserClicksOnTheMultipleSelectedProductAddToCartButton()
        {
            homePO.clicksOnMultipleAddToCartBTN();
        }*/
        [Then(@"user can see multiple selected product add to the cart icon")]
        public void ThenUserCanSeeMultipleSelectedProductAddToTheCartIcon()
        {
            homePO.verifyAddToCartIcon2();
        }
        [When(@"user select ""([^""]*)"" option in the sort dropdown")]
        public void WhenUserSelectOptionInTheSortDropdown(string sort)
        {
            homePO.selectSortDropDown(sort);
        }
       /* [Then(@"user can see products are sorted in decending order")]
        public void ThenUserCanSeeProductsAreSortedInDecendingOrder()
        {
            homePO.verifytSortProdcut();
        }*/
        [Then(@"user can see products are sorted in ""([^""]*)"" order")]
        public void ThenUserCanSeeProductsAreSortedInOrder(string dd)
        {
            homePO.verifySortProductOrder(dd);
        }
        [When(@"user click on the ""([^""]*)"" option in main menu")]
        public void WhenUserClickOnTheOptionInMainMenu(string menu)
        {
            homePO.clicksOnMainMenuOPT(menu);
        }
        [Then(@"user will navigate to about page")]
        public void ThenUserWillNavigateToAboutPage()
        {
            aboutPO.verifyAboutPage();

        }


    }
}
