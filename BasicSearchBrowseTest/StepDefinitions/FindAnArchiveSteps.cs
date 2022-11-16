using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class FindAnArchiveSteps
    {
        public IWebDriver _driver;

        [Given(@"I am on discovery home page to test find an archive")]
        public void GivenIAmOnDiscoveryHomePageToTestFindAnArchive()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();

            Thread.Sleep(2000);
            _driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("hide_this_message")).Click();
        }

       
        [When(@"I enter ""(.*)"" in the search bar")]
        public void WhenIEnterInTheSearchBar(string country)
        {
            _driver.FindElement(By.Id("archive-search")).SendKeys(country);
            _driver.FindElement(By.Id("submit")).Click();
        }
        [Then(@"Location should have ""(.*)""")]
        public void ThenLocationShouldHave(string country)
        {
            var trPlace = _driver.FindElements(By.Id("search-results")).FirstOrDefault(x => x.Text.Contains("Location:"));
            var actualLocation = trPlace.FindElement(By.TagName("tr")).Text;
            Assert.IsTrue(actualLocation.Contains(country));
            _driver.Quit();
        }
        [When(@"go to more options click on ""(.*)"" and ""(.*)""")]
        public void WhenGoToMoreOptionsClickOnAnd(string letter, string country)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");
            _driver.FindElement(By.LinkText("more options")).Click();
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.LinkText(letter)).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.LinkText(country)).Click();

        }
        [When(@"I select ""(.*)"", ""(.*)"" under Find UK archives")]
        public void WhenISelectUnderFindUKArchives(string region, string county)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.LinkText("more options")).Click();
            SelectElement dropDown = new SelectElement(_driver.FindElement(By.XPath("//select[@name='selection']")));
            dropDown.SelectByText(region);
            _driver.FindElement(By.LinkText(county)).Click();
        }

        [Then(@"I should see the filter ""(.*)"", ""(.*)""")]
        public void ThenIShouldSeeTheFilter(string region, string county)
        {
            String yourFilter = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue(yourFilter.Contains(region));
            Assert.IsTrue(yourFilter.Contains(county));
            _driver.Quit();
        }
        [Given(@"I am on find an archive page")]
        public void GivenIAmOnFindAnArchivePage()
        {
            _driver = new PageNavigator().GoToFindAnArchivePage();

            Thread.Sleep(2000);
            _driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("hide_this_message")).Click();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            _driver.FindElement(By.Id("archive-search")).SendKeys(searchTerm);
            _driver.FindElement(By.Id("submit")).Click();
        }

        [When(@"click on exportthe first thousand records in ""(.*)"", download")]
        public void WhenClickOnExporttheFirstThousandRecordsInDownload(string selectFormat)
        {
            _driver.FindElement(By.LinkText("Export results")).Click();
            _driver.FindElement(By.Id("dType")).Click();
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("dType")));
            oSelect.SelectByValue(selectFormat);
        }

        [Then(@"check we are able to download and check the file that has been downloaded")]
        public void ThenCheckWeAreAbleToDownloadAndCheckTheFileThatHasBeenDownloaded()
        {
            _driver.FindElement(By.XPath("//input[@value='Download']")).Click();
            Thread.Sleep(6000);
            // check the downloaded file manually 
            // check for filter results
            string filters = _driver.FindElement(By.Id("search-filters")).Text;
            Assert.IsTrue(filters.Contains("Filter results"));
            _driver.Quit();
        }
        [When(@"click on Export all the records as CSV download")]
        public void WhenClickOnExportAllTheRecordsAsCSVDownload()
        {
            _driver.FindElement(By.LinkText("Export results")).Click();
            _driver.FindElement(By.Id("exp10")).Click();
        }
        [When(@"I choose a ""(.*)""")]
        public void WhenIChooseA(string homeNation)
        {
            _driver.FindElement(By.LinkText(homeNation)).Click();
        }
        [When(@"check for the filters ""(.*)"", ""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void WhenCheckForTheFilters(string special, string local, string university, string typeOfArchiveprivate, string national)
        {
            string filters = _driver.FindElement(By.Id("search-filters")).Text;
            Assert.IsTrue(filters.Contains(special) && filters.Contains(local) &&
                filters.Contains(university) && filters.Contains(typeOfArchiveprivate) && filters.Contains(national) );
        }

        

    }
}
