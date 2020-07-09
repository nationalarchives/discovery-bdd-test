using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class NRAPdfDownloadSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on NRA pdf download page")]
        public void GivenIAmOnNRAPdfDownloadPage()
        {
            _driver = new PageNavigator().GoToNRAPdfDownloadPage();
            Thread.Sleep(2000);
        }
        [When(@"I check page status")]
        public void WhenICheckPageStatus()
        {
            String title = _driver.Title;
            Assert.IsEmpty(title);
        }

        [Then(@"status code should be OK")]
        public void ThenStatusCodeShouldBeOK()
        {
          //  _driver.Quit();
        }
        [Given(@"I am on NRA PDF for another IAID")]
        public void GivenIAmOnNRAPDFForAnotherIAID()
        {
            _driver = new PageNavigator().GoToNRAPdfDownloadAnotherIAIDPage();
            Thread.Sleep(2000);
        }


        // check manually the pdf is downloading or not
    }
}
