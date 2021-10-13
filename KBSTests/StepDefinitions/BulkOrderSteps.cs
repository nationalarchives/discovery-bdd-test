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
            js.ExecuteScript("window.scrollTo(0, 600)");
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
            js.ExecuteScript("window.scrollTo(0, 2700)");
            _driver.FindElement(By.XPath(" //input[@name='Email' and @type='text']")).SendKeys(email);
            _driver.FindElement(By.XPath("  //input[@name='Phone' and @type='text'] ")).SendKeys(telNo);
            //_driver.FindElement(By.Id("terms-conditions")).Selected = true;
               // ("checkbox").checked = true;
            _driver.FindElement(By.Id("terms-conditions")).Click();
            Thread.Sleep(2000);

            _driver.FindElement(By.XPath("//button[@name='submitbutton'] ")).Click();


        }

        [Then(@"check the page title, click on Order documents now")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsNow()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void ThenEnter(string series, string DocRef1, string DocRef2, string DocRef3, string DocRef4, string DocRef5, string DocRef6, string DocRef7, string DocRef8, string DocRef9, string DocRef10, string DocRef11, string DocRef12, string DocRef13, string DocRef14, string DocRef15, string DocRef16, string DocRef17, string DocRef18, string DocRef19, string DocRef20)
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


        }
        //[Then(@"enter forty document references ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",")]
        //public void ThenEnterFortyDocumentReferences(string series, string DocRef1, string DocRef2, string DocRef3, string DocRef4, string DocRef5, string DocRef6, string DocRef7, string DocRef8, string DocRef9, string DocRef10, string DocRef11, string DocRef12, string DocRef13, string DocRef14, string DocRef15, string DocRef16, string DocRef17, string DocRef18, string DocRef19, string DocRef20, string DocRef21, string DocRef22, string DocRef23, string DocRef24, string DocRef25, string DocRef26, string DocRef27, string DocRef28, string DocRef29, string DocRef30, string DocRef31, string DocRef32, string DocRef33, string DocRef34, string DocRef35, string DocRef36, string DocRef37, string DocRef38, string DocRef39, string DocRef40)
        //{
        //    _driver.FindElement(By.Id("Series")).SendKeys(series);
        //    _driver.FindElement(By.Id("DocumentReference1")).SendKeys(DocRef1);
        //    _driver.FindElement(By.Id("DocumentReference2")).SendKeys(DocRef2);
        //    _driver.FindElement(By.Id("DocumentReference3")).SendKeys(DocRef3);
        //    _driver.FindElement(By.Id("DocumentReference4")).SendKeys(DocRef4);
        //    _driver.FindElement(By.Id("DocumentReference5")).SendKeys(DocRef5);
        //    _driver.FindElement(By.Id("DocumentReference6")).SendKeys(DocRef6);
        //    _driver.FindElement(By.Id("DocumentReference7")).SendKeys(DocRef7);
        //    _driver.FindElement(By.Id("DocumentReference8")).SendKeys(DocRef8);
        //    _driver.FindElement(By.Id("DocumentReference9")).SendKeys(DocRef9);
        //    _driver.FindElement(By.Id("DocumentReference10")).SendKeys(DocRef10);
        //    _driver.FindElement(By.Id("DocumentReference11")).SendKeys(DocRef11);
        //    _driver.FindElement(By.Id("DocumentReference12")).SendKeys(DocRef12);
        //    _driver.FindElement(By.Id("DocumentReference13")).SendKeys(DocRef13);
        //    _driver.FindElement(By.Id("DocumentReference14")).SendKeys(DocRef14);
        //    _driver.FindElement(By.Id("DocumentReference15")).SendKeys(DocRef15);
        //    _driver.FindElement(By.Id("DocumentReference16")).SendKeys(DocRef16);
        //    _driver.FindElement(By.Id("DocumentReference17")).SendKeys(DocRef17);
        //    _driver.FindElement(By.Id("DocumentReference18")).SendKeys(DocRef18);
        //    _driver.FindElement(By.Id("DocumentReference19")).SendKeys(DocRef19);
        //    _driver.FindElement(By.Id("DocumentReference20")).SendKeys(DocRef20);
        //    _driver.FindElement(By.Id("DocumentReference21")).SendKeys(DocRef21);
        //    _driver.FindElement(By.Id("DocumentReference22")).SendKeys(DocRef22);
        //    _driver.FindElement(By.Id("DocumentReference23")).SendKeys(DocRef23);
        //    _driver.FindElement(By.Id("DocumentReference24")).SendKeys(DocRef24);
        //    _driver.FindElement(By.Id("DocumentReference25")).SendKeys(DocRef25);
        //    _driver.FindElement(By.Id("DocumentReference26")).SendKeys(DocRef26);
        //    _driver.FindElement(By.Id("DocumentReference27")).SendKeys(DocRef27);
        //    _driver.FindElement(By.Id("DocumentReference28")).SendKeys(DocRef28);
        //    _driver.FindElement(By.Id("DocumentReference29")).SendKeys(DocRef29);
        //    _driver.FindElement(By.Id("DocumentReference30")).SendKeys(DocRef30);
        //    _driver.FindElement(By.Id("DocumentReference31")).SendKeys(DocRef31);
        //    _driver.FindElement(By.Id("DocumentReference32")).SendKeys(DocRef32);
        //    _driver.FindElement(By.Id("DocumentReference33")).SendKeys(DocRef33);
        //    _driver.FindElement(By.Id("DocumentReference34")).SendKeys(DocRef34);
        //    _driver.FindElement(By.Id("DocumentReference35")).SendKeys(DocRef35);
        //    _driver.FindElement(By.Id("DocumentReference36")).SendKeys(DocRef36);
        //    _driver.FindElement(By.Id("DocumentReference37")).SendKeys(DocRef37);
        //    _driver.FindElement(By.Id("DocumentReference38")).SendKeys(DocRef38);
        //    _driver.FindElement(By.Id("DocumentReference39")).SendKeys(DocRef39);
        //    _driver.FindElement(By.Id("DocumentReference40")).SendKeys(DocRef40);
        //}
        [Then(@"check the page title, click on Order documents later")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsLater()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"check the page title, click on Yes, I’d like to order my documents later")]
        public void ThenCheckThePageTitleClickOnYesIDLikeToOrderMyDocumentsLater()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"check the page title, click on No, I’d like to order my documents now")]
        public void ThenCheckThePageTitleClickOnNoIDLikeToOrderMyDocumentsNow()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
