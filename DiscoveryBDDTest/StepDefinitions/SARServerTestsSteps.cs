using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class SARServerTestsSteps
    {
        public IWebDriver _driver;

        [Given(@"I am on details page for SAR server ""(.*)""")]
        public void GivenIAmOnDetailsPageForSARServer(string iaID)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDetailsPageOffsite("r", iaID);
        }
        
        [When(@"I check the catalogue description")]
        public void WhenICheckTheCatalogueDescription()
        {
            string title = _driver.Title;
            Assert.IsTrue(title.Contains("The National Archives"));
        }
        
        [Then(@"I should see ""(.*)"", ""(.*)"",""(.*)"" in catalogue description")]
        public void ThenIShouldSeeInCatalogueDescription(string assetDetails1, string assetDetails2, string assetDetails3)
        {
            string assetDetails = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue((assetDetails.Contains(assetDetails1)) && (assetDetails.Contains(assetDetails2)) && (assetDetails.Contains(assetDetails3)));
            _driver.Quit();
        }
    }
}
