using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class SubscriptionMoDMedalResearchOfficeSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on reader ticket demo page")]
        public void GivenIAmOnReaderTicketDemoPage()
        {
            _driver = new PageNavigator().GoToReaderTicketDemoPage();
        }
        
        [When(@"I click on reder ticket demo button and enter ""(.*)""")]
        public void WhenIClickOnRederTicketDemoButtonAndEnter(int barcodeNumber)
        {
            _driver.FindElement(By.ClassName("button")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("ticket")).SendKeys("110110");
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@value='Validate barcode']")).Click();
            Thread.Sleep(1000);
        }
        
        [Then(@"I should see Subscription\(MoD Medal Research Office\) in the home page")]
        public void ThenIShouldSeeSubscriptionMoDMedalResearchOfficeInTheHomePage()
        {
            string title = _driver.FindElement(By.XPath("//*[@id='account-controls']/ul/li[1]")).Text;
            Assert.IsTrue(title.Contains("Subscription (MoD Medal Research Office)"));
        }
    }
}
