using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class BulkOrderSteps
    {
        public IWebDriver _driver;

        [Given(@"Go to KBS page")]
        public void GivenGoToKBSPage()
        {
            _driver = new PageNavigator().GoToKBSPage();

            // Accept cookies
            //Thread.Sleep(2000);
            //_driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            //Thread.Sleep(2000);
            //_driver.FindElement(By.Id("hide_this_message")).Click();
        }
        
        [When(@"click on Select a date under book a bulk order visit")]
        public void WhenClickOnSelectADateUnderBookABulkOrderVisit()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.XPath("//a[contains(@href, '/book-a-reading-room-visit/bulk-order-visit/availability')]")).Click();
        }
        
        [When(@"click on date in the first row")]
        public void WhenClickOnDateInTheFirstRow()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 900)");

            _driver.FindElement(By.XPath("//button[@type='submit' and @id='first-available'] ")).Click();


        }
        
        [When(@"enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" and complete booking")]
        public void WhenEnterAndCompleteBooking(string readerTicketNo, string firstName, string lastName, string email, string telNo)
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

        [Then(@"check the page title, click on Order documents now")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsNow()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Your visit details - bulk order booking"));
            // string provisionalBookingMsg = _driver.FindElement(By.ClassName("row")).Text;
            // Assert.IsTrue(provisionalBookingMsg.Contains("You have made a provisional booking to visit the reading rooms"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.LinkText("Order documents now")).Click();
        }
        [Then(@"enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void ThenEnter(string series, string DocRef1, string DocRef2, string DocRef3, string DocRef4, string DocRef5, string DocRef6, string DocRef7, string DocRef8, string DocRef9, string DocRef10)
        {
            _driver.FindElement(By.Id("Series")).SendKeys(series);
            _driver.FindElement(By.Id("DocumentReference1")).SendKeys(DocRef1);
            _driver.FindElement(By.Id("DocumentReference2")).SendKeys(DocRef2);
            _driver.FindElement(By.Id("DocumentReference3")).SendKeys(DocRef3);
            _driver.FindElement(By.Id("DocumentReference4")).SendKeys(DocRef4);
            _driver.FindElement(By.Id("DocumentReference5")).SendKeys(DocRef5);
            _driver.FindElement(By.Id("DocumentReference6")).SendKeys(DocRef6);
            _driver.FindElement(By.Id("DocumentReference7")).SendKeys(DocRef7);
            _driver.FindElement(By.Id("DocumentReference8")).SendKeys(DocRef8);
            _driver.FindElement(By.Id("DocumentReference9")).SendKeys(DocRef9);
            _driver.FindElement(By.Id("DocumentReference10")).SendKeys(DocRef10);
        }

        [Then(@"enter all the doc reference numbers ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void ThenEnterAllTheDocReferenceNumbers(string DocRef11, string DocRef12, string DocRef13, string DocRef14, string DocRef15, string DocRef16, string DocRef17, string DocRef18, string DocRef19, string DocRef20)
        {
            _driver.FindElement(By.Id("DocumentReference11")).SendKeys(DocRef11);
            _driver.FindElement(By.Id("DocumentReference12")).SendKeys(DocRef12);
            _driver.FindElement(By.Id("DocumentReference13")).SendKeys(DocRef13);
            _driver.FindElement(By.Id("DocumentReference14")).SendKeys(DocRef14);
            _driver.FindElement(By.Id("DocumentReference15")).SendKeys(DocRef15);
            _driver.FindElement(By.Id("DocumentReference16")).SendKeys(DocRef16);
            _driver.FindElement(By.Id("DocumentReference17")).SendKeys(DocRef17);
            _driver.FindElement(By.Id("DocumentReference18")).SendKeys(DocRef18);
            _driver.FindElement(By.Id("DocumentReference19")).SendKeys(DocRef19);
            _driver.FindElement(By.Id("DocumentReference20")).SendKeys(DocRef20);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 2300)");
            Thread.Sleep(2000);

            _driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Click();
        }
        [Then(@"check the page title order summary")]
        public void ThenCheckThePageTitleOrderSummary()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Order summary - bulk order booking - The National Archives"));
        }

        [Then(@"click on cancel your visit, check the page title and proceed")]
        public void ThenClickOnCancelYourVisitCheckThePageTitleAndProceed()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 3400)");
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Cancellation confirmation - bulk order booking - The National Archives"));
        }

        [Then(@"I can see the message Your visit has been cancelled on the top of the page")]
        public void ThenICanSeeTheMessageYourVisitHasBeenCancelledOnTheTopOfThePage()
        {

            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Cancellation confirmation - bulk order booking - The National Archives"));

        }


        [Then(@"check the page title, click on Order documents later")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsLater()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Your visit details - bulk order booking - The National Archives"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.LinkText("Order documents later")).Click();
        }

        [Then(@"check the page title, click on Yes, I’d like to order my documents later")]
        public void ThenCheckThePageTitleClickOnYesIDLikeToOrderMyDocumentsLater()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Continue later - bulk order booking - The National Archives"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 900)");
            _driver.FindElement(By.LinkText("Yes, I’d like to order my documents later")).Click();
            string pgTitle1 = _driver.Title;
            Assert.IsTrue(pgTitle1.Contains("Continue later confirmation - The National Archives"));
        }
        [Then(@"check the page title, click on No, I’d like to order my documents now")]
        public void ThenCheckThePageTitleClickOnNoIDLikeToOrderMyDocumentsNow()
        {
            string pgTitle = _driver.Title;
            Assert.IsTrue(pgTitle.Contains("Continue later - bulk order booking - The National Archives"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 900)");
            _driver.FindElement(By.LinkText("No, I’d like to order my documents now")).Click();
        }

    }
}
