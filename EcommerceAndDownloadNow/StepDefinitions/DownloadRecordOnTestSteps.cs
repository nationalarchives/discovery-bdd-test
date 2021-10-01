using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class DownloadRecordOnTestSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on download page for offsite ""(.*)"" and signedIn")]
        public void GivenIAmOnDownloadPageForOffsiteAndSignedIn(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDetailsPageOffsite("r", iaId);
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("hide_this_message")).Click();
            _driver.FindElement(By.Id("signin")).Click();
            webDriver.SingleSignOn(_driver);
        }

        [When(@"I add to basket,submit order, pay using paypal")]
        public void WhenIAddToBasketSubmitOrderPayUsingPaypal()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("Add to basket")).Click();
            _driver.FindElement(By.LinkText("Go to basket")).Click();
            // _driver.FindElement(By.LinkText("Continue to basket")).Click();
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            _driver.FindElement(By.Id("confirm-terms")).Click();
            _driver.FindElement(By.XPath("//input[@value='Submit order']")).Click();
            //_driver.FindElement(By.XPath("//a[@id='link_PAYPAL-EXPRESS']/font")).Click();
            //Thread.Sleep(2000);
           // _driver.FindElement(By.XPath("//input[@id='PMMakePayment']")).Click();
        }
        
        [Then(@"check for the message Thank you for your order and check we are able to Download")]
        public void ThenCheckForTheMessageThankYouForYourOrderAndCheckWeAreAbleToDownload()
        {
            string thankYouOrder = _driver.FindElement(By.XPath("//div[@class='heading-holding-banner']/h1/span")).Text;
            Assert.AreEqual("Thank you for your order", thankYouOrder);
            _driver.FindElement(By.LinkText("Download now")).Click();
            string verifyDownload = _driver.FindElement(By.XPath("(//a[@class='download-part discoveryPrimaryCallToActionLink'])[1]")).Text;
            Assert.AreEqual("Download", verifyDownload);
            _driver.FindElement(By.LinkText("Download")).Click();
           // _driver.Quit();
        }
        [Then(@"go to your orders in the account and check for the ""(.*)""")]
        public void ThenGoToYourOrdersInTheAccountAndCheckForThe(string orderDetails)
        {
            _driver.FindElement(By.Id("signInLink")).Click();
            _driver.FindElement(By.LinkText("Your orders")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            string orderTitle = _driver.FindElement(By.XPath("//li/h3")).Text;
            Assert.IsTrue(orderTitle.Contains(orderDetails));
        }

        [Then(@"check we are able to download")]
        public void ThenCheckWeAreAbleToDownload()
        {
            _driver.FindElement(By.LinkText("Download now")).Click();
            Thread.Sleep(4000);
            _driver.FindElement(By.Id("signInLink")).Click();
            _driver.FindElement(By.LinkText("Your orders")).Click();
            string title = _driver.Title;
            Assert.IsTrue(title.Contains("Your orders"));
           // string verifyDownload = _driver.FindElement(By.XPath("(//a[@class='download-part discoveryPrimaryCallToActionLink'])[1]")).Text;
           // Assert.AreEqual("Download", verifyDownload);
           // _driver.FindElement(By.LinkText("Download")).Click();
            _driver.Quit();
        }
        [Given(@"I am on download page for staffin ""(.*)""")]
        public void GivenIAmOnDownloadPageForStaffin(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);
        }

        [When(@"signedIn")]
        public void WhenSignedIn()
        {
            var webDriver = new PageNavigator();
            _driver.FindElement(By.Id("signin")).Click();
            webDriver.SingleSignOn(_driver);
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("hide_this_message")).Click();
        }

    }
}
