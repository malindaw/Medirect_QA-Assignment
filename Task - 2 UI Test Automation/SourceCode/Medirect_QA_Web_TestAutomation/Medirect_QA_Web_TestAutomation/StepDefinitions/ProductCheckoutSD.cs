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
    public class ProductCheckoutSD
    {        
        CartPage cartPO = new CartPage();
        InformationPage infoPO = new InformationPage();
        OverviewPage overviewPO = new OverviewPage();
        CompletePage completePO = new CompletePage();
        HomePage homePO = new HomePage();


        [When(@"user clicks on cart icon")]
        public void WhenUserClicksOnCartIcon()
        {
            homePO.clicksOnCartIcon();
        }
        [Then(@"user can see his own cart")]
        public void ThenUserCanSeeHisOwnCart()
        {
            cartPO.verifyOwnCartPage();
        }
        [When(@"user clicks on the checkout button")]
        public void WhenUserClicksOnTheCheckoutButton()
        {
            cartPO.clicksOnCheckOutBTN();  
        }
        [Then(@"user can see personal information page")]
        public void ThenUserCanSeePersonalInformationPage()
        {
            infoPO.verifyInformationPage();
        }
        [When(@"user add following details")]
        public void WhenUserAddFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            infoPO.fillingInformation((string)data.Firstname, (string)data.Lastname, (int)data.Postalcode);
        }
        [When(@"user clicks on the continue button")]
        public void WhenUserClicksOnTheContinueButton()
        {
            infoPO.clicksOnContinueBTN();
        }
        [Then(@"user can see add information overview")]
        public void ThenUserCanSeeAddInformationOverview()
        {
            overviewPO.verifyOverviewPageTitle();
        }
        [When(@"user clicks on the finish button")]
        public void WhenUserClicksOnTheFinishButton()
        {
            overviewPO.clicksOnFinishBTN();
        }
        [Then(@"user navigate to complete page")]
        public void ThenUserNavigateToCompletePage()
        {
            completePO.verifyCompletePageTitle();
            completePO.verifyCompletePageDispatchMSG();
        }
        [Then(@"user can see field validation")]
        public void ThenUserCanSeeFieldValidation()
        {
            infoPO.verifyInfoValidateMSG();
        }
        [When(@"user clicks on the product Remove button")]
        public void WhenUserClicksOnTheProductRemoveButton()
        {
            cartPO.clicksOnProductRemoveBTN();
        }
        [Then(@"user can see selected product removed from the list")]
        public void ThenUserCanSeeSelectedProductRemovedFromTheList()
        {
            cartPO.verifySelectProductRemovedInCartPage();
        }


    }
}
