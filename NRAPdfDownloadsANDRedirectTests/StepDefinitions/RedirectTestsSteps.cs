using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class RedirectTestsSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on redirect A(.*)A page")]
        public void GivenIAmOnRedirectAAPage(int p0)
        {
            _driver = new PageNavigator().GoToA2ARedirectsPage();
        }

    
        [When(@"I check the title")]
        public void WhenICheckTheTitle()
        {
            string title = _driver.Title;
        }
        
        [Then(@"the title should be Talbot Papers")]
        public void ThenTheTitleShouldBeTalbotPapers()
        {
            string title = _driver.Title;
            Assert.IsTrue(title.Contains("Talbot Papers"));
        }
        [Given(@"I am on redirect NRA page")]
        public void GivenIAmOnRedirectNRAPage()
        {
            _driver = new PageNavigator().GoToNRARedirectsPage();
        }
        [Then(@"the title should be national archives")]
        public void ThenTheTitleShouldBeNationalArchives()
        {
            string title = _driver.Title;
            Assert.IsTrue(title.Contains("The National Archives"));
        }

    }
}
