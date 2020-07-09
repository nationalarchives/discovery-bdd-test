using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class DeliveryOptions_2Steps
    {
        public IWebDriver _driver;
        [Given(@"I am on delivery options page ""(.*)""")]
        public void GivenIAmOnDeliveryOptionsPage(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);
        }
        [When(@"check the ""(.*)"" for staffin ""(.*)""")]
        public void WhenCheckTheForStaffin(string message, string xPath)
        {
            if (!string.IsNullOrWhiteSpace(xPath))
            {
                string staffinMessage = _driver.FindElement(By.XPath(xPath)).Text;
                Assert.IsTrue(staffinMessage.Contains(message));
            }
        }

        [Then(@"check for the page ""(.*)""")]
        public void ThenCheckForThePage(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                string pgTitle = _driver.Title;
                Assert.IsTrue(pgTitle.Contains(title));
            }
            _driver.Quit();
        }
        [When(@"click on view delivery options presented to other users ""(.*)""")]
        public void WhenClickOnViewDeliveryOptionsPresentedToOtherUsers(string xPathDO)
        {
            _driver.FindElement(By.XPath(xPathDO)).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
        }

        [When(@"check the ""(.*)"" onsite or offsite ""(.*)""")]
        public void WhenCheckTheOnsiteOrOffsite(string xPath, string message)
        {
            string actual = _driver.FindElement(By.XPath(xPath)).Text;
            Assert.IsTrue(actual.Contains(message));
        }

        [Then(@"click on the ""(.*)""")]
        public void ThenClickOnThe(string button)
        {
            if (!string.IsNullOrWhiteSpace(button))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(0, 800)");
                _driver.FindElement(By.LinkText(button)).Click();
                Thread.Sleep(2000);
            }
        }
        [When(@"I click on contact us button")]
        public void WhenIClickOnContactUsButton()
        {
            _driver.FindElement(By.ClassName("discoveryPrimaryCallToActionLink")).Click();
        }
     
        [When(@"click on More ways to view this record")]
        public void WhenClickOnMoreWaysToViewThisRecord()
        {
            _driver.FindElement(By.LinkText("More ways to view this record")).Click();
        }
        [When(@"I should see Also available from: Ancestry")]
        public void WhenIShouldSeeAlsoAvailableFromAncestry()
        {
            string actual = _driver.FindElement(By.CssSelector(".supplemental-content > section")).Text;
            Assert.IsTrue(actual.Contains("Also available from:")&& actual.Contains("Ancestry"));
        }

        [Then(@"Hide More ways to view this record")]
        public void ThenHideMoreWaysToViewThisRecord()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("More ways to view this record")).Click();
        }

        [Then(@"I shouldn't see Also available from: Ancestry")]
        public void ThenIShouldnTSeeAlsoAvailableFromAncestry()
        {
            string actual = _driver.FindElement(By.ClassName("order-option-wrapper")).Text;
            Assert.IsFalse(actual.Contains("Ancestry"));
        }
        [When(@"I should see Also available from:  The Genealogist Ancestry")]
        public void WhenIShouldSeeAlsoAvailableFromTheGenealogistAncestry()
        {
            string actual = _driver.FindElement(By.CssSelector(".supplemental-content > section")).Text;
            Assert.IsTrue(actual.Contains("Also available from:") && actual.Contains("The Genealogist") && actual.Contains("Ancestry"));
        }

        [Then(@"I shouldn't see Also available from: The Genealogist Ancestry")]
        public void ThenIShouldnTSeeAlsoAvailableFromTheGenealogistAncestry()
        {
            string actual = _driver.FindElement(By.ClassName("order-option-wrapper")).Text;
            Assert.IsFalse(actual.Contains("Ancestry"));
        }
        [Then(@"check the basket has one item")]
        public void ThenCheckTheBasketHasOneItem()
        {
            string basket = _driver.FindElement(By.Id("miniBasket")).Text;
            Assert.IsTrue(basket.Contains("1 item"));
        }
        [When(@"I should see Available to view free at TNA")]
        public void WhenIShouldSeeAvailableToViewFreeAtTNA()
        {
            string actual = _driver.FindElement(By.CssSelector("section > ul a")).Text;
            Thread.Sleep(2000);
            Assert.IsTrue(actual.Contains("Available to view free at The National Archives"));
        }

        [Then(@"I shouldn't see Available to view free at TNA")]
        public void ThenIShouldnTSeeAvailableToViewFreeAtTNA()
        {
            Thread.Sleep(2000);
            string actual = _driver.FindElement(By.ClassName("order-option-wrapper")).Text;
            Thread.Sleep(2000);
            Assert.IsFalse(actual.Contains("Available to view free at The National Archives"));
        }

        // digitisedLia stepdefs
        [When(@"I click on More ways to view this record for offsite")]
        public void WhenIClickOnMoreWaysToViewThisRecordForOffsite()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.XPath("(//a[contains(text(),'More ways to view this record')])[2]")).Click();
        }
     
        [When(@"click on ""(.*)"" for offsite")]
        public void WhenClickOnForOffsite(string xpath)
        {
            if (!string.IsNullOrWhiteSpace(xpath))
            {
                _driver.FindElement(By.XPath(xpath)).Click();
            }
        }

        // File Authority step defs
        [Given(@"I am on delivery options page for fileAuthority ""(.*)""")]
        public void GivenIAmOnDeliveryOptionsPageForFileAuthority(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("c", iaId);
        }

        [When(@"click on view details of this record creator")]
        public void WhenClickOnViewDetailsOfThisRecordCreator()
        {
            _driver.FindElement(By.Id("name-authority")).Click();
        }
        [When(@"scroll down")]
        public void WhenScrollDown()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
        }
    }
}
