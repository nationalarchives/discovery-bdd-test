using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace KBSTests.StepDefinitions
{
    [Binding]
    public class StandardOrderSteps
    {
        private IWebDriver _driver;

        [Given(@"Go to KBS page for standard order")]
        public void GivenGoToKBSPageForStandardOrder()
        {
            _driver = new PageNavigator().GoToKBSPage();
            // Accept cookies
            //Thread.Sleep(2000);
            //_driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            //Thread.Sleep(2000);
            //_driver.FindElement(By.Id("hide_this_message")).Click();
        }

        [When(@"click on Select a date under book a standard order visit")]
        public void WhenClickOnSelectADateUnderBookAStandardOrderVisit()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.XPath("//a[contains(@href, '/book-a-reading-room-visit/standard-order-visit/availability')]")).Click();
        }

        [When(@"click on date in the first row for standard order")]
        public void WhenClickOnDateInTheFirstRowForStandardOrder()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 900)");

            _driver.FindElement(By.XPath("//button[@type='submit' and @id='first-available'] ")).Click();
        }
        
        [When(@"enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" and complete booking for standard order")]
        public void WhenEnterAndCompleteBookingForStandardOrder(string readerTicketNo, string firstName, string lastName, string email, string telNo)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 900)");
            _driver.FindElement(By.XPath("//input[@name='Ticket' and @type='text'] ")).SendKeys(readerTicketNo);
            _driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _driver.FindElement(By.XPath("//input[@name='LastName' and @type='text']")).SendKeys(lastName);
            //js.ExecuteScript("window.scrollTo(0, 2700)");
            _driver.FindElement(By.XPath(" //input[@name='Email' and @type='text']")).SendKeys(email);
            _driver.FindElement(By.XPath("  //input[@name='Phone' and @type='text'] ")).SendKeys(telNo);
            //_driver.FindElement(By.Id("terms-conditions")).Selected = true;
            // ("checkbox").checked = true;
            // _driver.FindElement(By.Id("terms-conditions")).Click();
            _driver.FindElement(By.Id("terms-conditions")).SendKeys(Keys.Space);
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollTo(0, 1700)");
            _driver.FindElement(By.XPath("//button[@name='submitbutton'] ")).Click();
        }
        
        [Then(@"check the page title, click on Order documents now for standard order")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsNowForStandardOrder()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("standard booking - The National Archives"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1900)");
            _driver.FindElement(By.LinkText("Order documents now")).Click();
        }
        
        [Then(@"enter two document references ""(.*)"",""(.*)"", enter ""(.*)""")]
        public void ThenEnterTwoDocumentReferencesEnter(string DocRef1, string DocRef2, string ReserveDocRef1)
        {
            _driver.FindElement(By.Id("DocumentReference1")).SendKeys(DocRef1);
            _driver.FindElement(By.Id("DocumentReference2")).SendKeys(DocRef2);
            _driver.FindElement(By.Id("ReserveDocumentReference1")).SendKeys(ReserveDocRef1);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 2300)");
            Thread.Sleep(2000);

            _driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
        }
        [Then(@"check the page title, click on Order documents later for standard order")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsLaterForStandardOrder()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("standard booking - The National Archives"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.LinkText("Order documents later")).Click();
            string pgTitle1 = _driver.Title;
            Assert.IsTrue(pgTitle1.Contains("Continue later - standard booking - The National Archives"));
            js.ExecuteScript("window.scrollTo(0, 900)");
            _driver.FindElement(By.LinkText("Yes, I’d like to order my documents later")).Click();
            string pgTitle2 = _driver.Title;
            Assert.IsTrue(pgTitle2.Contains("Continue later confirmation - The National Archives"));
        }

        [Then(@"click on cancel your visit, check the page title and proceed for standard order")]
        public void ThenClickOnCancelYourVisitCheckThePageTitleAndProceedForStandardOrder()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 3400)");
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Cancellation confirmation - standard booking - The National Archives"));
        }

        [Then(@"I can see the message Your visit has been cancelled")]
        public void ThenICanSeeTheMessageYourVisitHasBeenCancelled()
        {

            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Cancellation confirmation - standard booking - The National Archives"));

        }

    }
}
