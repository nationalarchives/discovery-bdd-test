using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class DownloadNow_Onsite_LargeAndZipFilesSteps
    {
        public IWebDriver _driver;

        [Given(@"I am on details page for large files ""(.*)""")]
        public void GivenIAmOnDetailsPageForLargeFiles(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDetailsPage("r", iaId);
        }
        [When(@"click on download now for zip files")]
        public void WhenClickOnDownloadNowForZipFiles()
        {
            _driver.FindElement(By.LinkText("Download now")).Click();
            Thread.Sleep(2000);
        }

        [When(@"click on download now")]
        public void WhenClickOnDownloadNow()
        {
            _driver.FindElement(By.LinkText("Download now")).Click();
            //_driver.FindElement(By.Id("progressButton")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("Download")).Click();
        }

        [Then(@"we can able to download the files")]
        public void ThenWeCanAbleToDownloadTheFiles()
        {
            //_driver.FindElement(By.LinkText("Download")).Click();
            Thread.Sleep(3000);
            String title = _driver.Title;
            Assert.IsTrue(title.Contains("The National Archives"));
            _driver.Quit();
        }
    }
}
