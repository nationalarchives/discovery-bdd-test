using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class WhatToExpectGuideSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on the details page for ""(.*)"" for offSite")]
        public void GivenIAmOnTheDetailsPageForForOffSite(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDetailsPageOffsite("r", iaId);


            Thread.Sleep(2000);
            _driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("hide_this_message")).Click();


            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 900)");
        }
        
        [When(@"click on ""(.*)"" for Did you find this guide helpful")]
        public void WhenClickOnForDidYouFindThisGuideHelpful(string button)
        {
            _driver.FindElement(By.XPath(button)).Click();
            Thread.Sleep(2000);
        }
        
        [When(@"check for the ""(.*)"" and ""(.*)""")]
        public void WhenCheckForTheAnd(string heading, string commentHeading)
        {
            string actual = _driver.FindElement(By.Id("what-to-expect-form")).Text;
            Thread.Sleep(2000);
            Assert.IsTrue(actual.Contains(heading) && actual.Contains(commentHeading));
        }

        [Then(@"enter ""(.*)"", ""(.*)""")]
        public void ThenEnter(string feedback, string acknowledge)
        {
            _driver.FindElement(By.Id("comments")).SendKeys(feedback);
            //Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            //click on send
            _driver.FindElement(By.XPath("//*[@id='no_fieldset']/button[1]")).Click();
            Thread.Sleep(2000);
            string actual = _driver.FindElement(By.Id("what-to-expect-form")).Text;
            Thread.Sleep(2000);
            Assert.IsTrue(actual.Contains(acknowledge));
            _driver.Quit();
        }
        [When(@"click on Read more, click on research guide")]
        public void WhenClickOnReadMoreClickOnResearchGuide()
        {
            _driver.FindElement(By.Id("expand-supplemental")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1200)");
            Thread.Sleep(2000);
            _driver.FindElement(By.LinkText("research guide")).Click();
        }

        [Then(@"check for the page title")]
        public void ThenCheckForThePageTitle()
        {
            string title = _driver.Title;
            Assert.IsTrue(title.Contains(" The National Archives"));
            _driver.Quit();
        }
        [When(@"click on Read more")]
        public void WhenClickOnReadMore()
        {
            _driver.FindElement(By.Id("expand-supplemental")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1200)");
            Thread.Sleep(2000);
        }

        [Then(@"click on Read less")]
        public void ThenClickOnReadLess()
        {
            _driver.FindElement(By.Id("expand-supplemental")).Click();
            _driver.Quit();
        }
        [When(@"click on View a page feom an example war diary")]
        public void WhenClickOnViewAPageFeomAnExampleWarDiary()
        {
            _driver.FindElement(By.ClassName("what-to-expect-image")).Click();

        }

        [Then(@"check for the title example record only")]
        public void ThenCheckForTheTitleExampleRecordOnly()
        {
            string imgTitle = _driver.FindElement(By.XPath("//*[@id='tnaModalComponent']/div/div[2]/div/figure/figcaption")).Text;
            Assert.IsTrue(imgTitle.Contains("Example record only"));
            _driver.Quit();
        }


    }
}
