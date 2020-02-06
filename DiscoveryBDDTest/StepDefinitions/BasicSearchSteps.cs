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
    public class BasicSearchSteps
    {
        public IWebDriver _driver;
        [Given(@"Given I am on Discovery Home page")]
        public void GivenGivenIAmOnDiscoveryHomePage()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
        }

        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(string keyword)
        {
            _driver.FindElement(By.Id("search-for")).SendKeys(keyword);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"the results should contain (.*)")]
        public void ThenTheResultsShouldContain(string keyword)
        {
            string results = _driver.FindElement(By.Id("search-results")).Text;
            Assert.IsTrue(results.Contains(keyword));
            _driver.Quit();
        }
        [Then(@"results should contain ""(.*)""")]
        public void ThenResultsShouldContain(string keyword)
        {
            string results = _driver.FindElement(By.Id("search-results")).Text;
            Assert.IsTrue(results.Contains(keyword));
            _driver.Quit();
        }
        [When(@"enter ""(.*)"", filter by TNA")]
        public void WhenEnterFilterByTNA(string word)
        {
            _driver.FindElement(By.Id("search-for")).SendKeys(word);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.LinkText("The National Archives")).Click();

        }

        [Then(@"check for the ""(.*)"",""(.*)"" got particular number of records")]
        public void ThenCheckForTheGotParticularNumberOfRecords(string collectionModule, string subjectsModule)
        {
            //string filters = _driver.FindElement(By.Id("search-filters")).Text;
            // check collections
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.XPath("//input[@id='"+ collectionModule +"']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//li[@id='department']/form/div/input")).Click();
            Thread.Sleep(2000);
            string numberOfRecords = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreNotEqual(numberOfRecords, "Records 0");
            // Remove filter
            _driver.FindElement(By.XPath("(//img[@alt='Remove'])[2]")).Click();
            // check subjects
            js.ExecuteScript("window.scrollTo(0, 1600)");
            _driver.FindElement(By.Id("subject-filters")).Click();
            _driver.FindElement(By.Id(subjectsModule)).Click();
            _driver.FindElement(By.Name("Refine subjects")).Click();
            string numberOfRecords1 = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreNotEqual(numberOfRecords1, "Records 0");
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"", check the total number of records and record creators are not zero")]
        public void WhenIEnterCheckTheTotalNumberOfRecordsAndRecordCreatorsAreNotZero(string keyword)
        {
            _driver.FindElement(By.Id("search-for")).SendKeys(keyword);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            string numberOfRecords = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreNotEqual(numberOfRecords, "Records 0");
            string numberOfRecordCreators = _driver.FindElement(By.Id("name-authorities-tab")).Text;
            Assert.AreNotEqual(numberOfRecordCreators, "Records 0");
        }

        [When(@"check for the sorting is only enabled message")]
        public void WhenCheckForTheSortingIsOnlyEnabledMessage()
        {
            string sortingMessage = _driver.FindElement(By.XPath("//span[@class='emphasis-block']")).Text;
            Assert.AreEqual(sortingMessage,
           "Sorting is only enabled when there are fewer than 10,000 results. Refine the search to reduce the number of results to enable sorting.");
        }

        [When(@"Export results in ""(.*)""")]
        public void WhenExportResultsIn(string selectFormat)
        {
            _driver.FindElement(By.LinkText("Export results")).Click();
            _driver.FindElement(By.Id("dType")).Click();
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("dType")));
            oSelect.SelectByValue(selectFormat);
        }

        [Then(@"we are able to download and check the file that has been downloaded")]
        public void ThenWeAreAbleToDownloadAndCheckTheFileThatHasBeenDownloaded()
        {
            _driver.FindElement(By.XPath("//input[@value='Download']")).Click();
            Thread.Sleep(6000);
            // check the downloaded file manually 
            // check for filter results
            string filters = _driver.FindElement(By.Id("search-filters")).Text;
            Assert.IsTrue(filters.Contains("Filter results"));
            _driver.Quit();
        }
        [When(@"go to record creators and Export results in ""(.*)""")]
        public void WhenGoToRecordCreatorsAndExportResultsIn(string selectFormat)
        {
            _driver.FindElement(By.Id("nameAuthorities")).Click();
            _driver.FindElement(By.LinkText("Export results")).Click();
            _driver.FindElement(By.Id("dType")).Click();
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("dType")));
            oSelect.SelectByValue(selectFormat);
        }
        [When(@"go to record creators,select ""(.*)"", select ""(.*)"" under export results")]
        public void WhenGoToRecordCreatorsSelectSelectUnderExportResults(string sortedBy, string selectFormat)
        {
            _driver.FindElement(By.Id("nameAuthorities")).Click();
            _driver.FindElement(By.Id("sortDrop")).Click();
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("sortDrop")));
            oSelect.SelectByText(sortedBy);
            _driver.FindElement(By.Id("show-download-form")).Click();
            _driver.FindElement(By.Id("dType")).Click();
            SelectElement oSelect1 = new SelectElement(_driver.FindElement(By.Id("dType")));
            oSelect1.SelectByValue(selectFormat);
        }
        [When(@"go to simple view, select ""(.*)"", select ""(.*)"" under export results")]
        public void WhenGoToSimpleViewSelectSelectUnderExportResults(string sortedBy, string selectFormat)
        {
            _driver.FindElement(By.Id("simple-view")).Click();
            _driver.FindElement(By.Id("sortDrop")).Click();
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("sortDrop")));
            oSelect.SelectByText(sortedBy);
            _driver.FindElement(By.Id("show-download-form")).Click();
            _driver.FindElement(By.Id("dType")).Click();
            SelectElement oSelect1 = new SelectElement(_driver.FindElement(By.Id("dType")));
            oSelect1.SelectByValue(selectFormat);
        }
        [When(@"go to ""(.*)"" select ""(.*)"", select all records as spreadsheet\(CSV\) under export results")]
        public void WhenGoToSelectSelectAllRecordsAsSpreadsheetCSVUnderExportResults(string recordsTab, string sortedBy)
        {
            _driver.FindElement(By.Id(recordsTab)).Click();
            _driver.FindElement(By.Id("sortDrop")).Click();
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("sortDrop")));
            oSelect.SelectByText(sortedBy);
            _driver.FindElement(By.LinkText("Export results")).Click();
            _driver.FindElement(By.Id("exp10")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
        }
        [When(@"I enter ""(.*)"", click on ""(.*)"" on the bottom")]
        public void WhenIEnterClickOnOnTheBottom(string keyword, string numberOfItemsPerPage)
        {
            _driver.FindElement(By.Id("search-for")).SendKeys(keyword);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.LinkText(numberOfItemsPerPage)).Click();
        }

        [Then(@"the number of records displaying per page should be ""(.*)""")]
        public void ThenTheNumberOfRecordsDisplayingPerPageShouldBe(int numberOfItemsPerPage)
        {
            var recordCount = _driver.FindElements(By.XPath("//ul[@id='search-results']/li")).Count;
            Assert.AreEqual(recordCount, numberOfItemsPerPage);
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"", go to record creators tab")]
        public void WhenIEnterGoToRecordCreatorsTab(string keyword)
        {
            _driver.FindElement(By.Id("search-for")).SendKeys(keyword);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            _driver.FindElement(By.Id("name-authorities-tab")).Click();
        }

        [Then(@"I can see the filters Organisation, person, business, Manor, Family, Diaries")]
        public void ThenICanSeeTheFiltersOrganisationPersonBusinessManorFamilyDiaries()
        {
            string yourFilters = _driver.FindElement(By.Id("search-filters")).Text;
            Assert.IsTrue(yourFilters.Contains("Organisation"));
            Assert.IsTrue(yourFilters.Contains("Person"));
            Assert.IsTrue(yourFilters.Contains("Business"));
            Assert.IsTrue(yourFilters.Contains("Manor"));
            Assert.IsTrue(yourFilters.Contains("Family"));
            Assert.IsTrue(yourFilters.Contains("Diaries"));
            _driver.Quit();
        }
        [When(@"click on opened in the last six months under Record opening date")]
        public void WhenClickOnOpenedInTheLastSixMonthsUnderRecordOpeningDate()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("opening-date-filters")).Click();
            Thread.Sleep(2000);
           // _driver.FindElement(By.Id("opening-date-filters")).Click();
            // _driver.FindElement(By.XPath("//a[contains(text(),'Record opening date')]")).Click();
            _driver.FindElement(By.Id("rod183")).Click();
            _driver.FindElement(By.Name("Refine record opening date")).Click();
        }

        [Then(@"click on the first record and check the record opening date should be in the last six months")]
        public void ThenClickOnTheFirstRecordAndCheckTheRecordOpeningDateShouldBeInTheLastSixMonths()
        {
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualOpeningDate = trRecordOpeningDate.FindElement(By.TagName("td")).Text;

            DateTime recordDate = DateTime.Parse(actualOpeningDate);

            DateTime nowDate = DateTime.Now;
            DateTime sixMonthsAgo = nowDate.AddMonths(-6);

            Assert.IsTrue((recordDate >= sixMonthsAgo) && (recordDate <= nowDate));
            _driver.Quit();
        }
        [When(@"click on opened in the last twelve months under Record opening date")]
        public void WhenClickOnOpenedInTheLastTwelveMonthsUnderRecordOpeningDate()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("opening-date-filters")).Click();
            Thread.Sleep(2000);
            //_driver.FindElement(By.Id("records-opening-date")).Click();
            // _driver.FindElement(By.XPath("//a[contains(text(),'Record opening date')]")).Click();
            _driver.FindElement(By.Id("rod365")).Click();
            _driver.FindElement(By.Name("Refine record opening date")).Click();
        }

        [Then(@"click on the first record and check the record opening date should be in the last twelve months")]
        public void ThenClickOnTheFirstRecordAndCheckTheRecordOpeningDateShouldBeInTheLastTwelveMonths()
        {
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[3]/a")).Click();
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualOpeningDate = trRecordOpeningDate.FindElement(By.TagName("td")).Text;

            DateTime recordDate = DateTime.Parse(actualOpeningDate);

            DateTime nowDate = DateTime.Now;
            DateTime twelveMonthsAgo = nowDate.AddMonths(-12);

            Assert.IsTrue((recordDate >= twelveMonthsAgo) && (recordDate <= nowDate));
            _driver.Quit();
        }

        [When(@"click on opened in the last week under Record opening date")]
        public void WhenClickOnOpenedInTheLastWeekUnderRecordOpeningDate()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("opening-date-filters")).Click();
            //_driver.FindElement(By.Id("records-opening-date")).Click();
            // _driver.FindElement(By.XPath("//a[contains(text(),'Record opening date')]")).Click();
            _driver.FindElement(By.Id("rod7")).Click();
            _driver.FindElement(By.Name("Refine record opening date")).Click();
           
        }

        [Then(@"click on the first record and check the record opening date should be in the last week")]
        public void ThenClickOnTheFirstRecordAndCheckTheRecordOpeningDateShouldBeInTheLastWeek()
        {
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
            Thread.Sleep(2000);
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualOpeningDate = trRecordOpeningDate.FindElement(By.TagName("td")).Text;

            DateTime recordDate = DateTime.Parse(actualOpeningDate);

            DateTime nowDate = DateTime.Now;
            DateTime oneWeekAgo = nowDate.AddDays(-8);

            Assert.IsTrue((recordDate >= oneWeekAgo) && (recordDate <= nowDate));
            _driver.Quit();
        }
        [When(@"click on opened during the last day under Record opening date")]
        public void WhenClickOnOpenedDuringTheLastDayUnderRecordOpeningDate()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("opening-date-filters")).Click();
           // _driver.FindElement(By.XPath("//a[contains(text(),'Record opening date')]")).Click();
            _driver.FindElement(By.Id("rod1")).Click();
            _driver.FindElement(By.Name("Refine record opening date")).Click();
        }

        [Then(@"click on the first record and check the record opening date should be yesterday")]
        public void ThenClickOnTheFirstRecordAndCheckTheRecordOpeningDateShouldBeYesterday()
        {
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualOpeningDate = trRecordOpeningDate.FindElement(By.TagName("td")).Text;

            DateTime recordDate = DateTime.Parse(actualOpeningDate);

            DateTime nowDate = DateTime.Now;
            DateTime yesterday = nowDate.AddDays(-1.5);

            Assert.IsTrue((recordDate >= yesterday) && (recordDate <= nowDate));
            _driver.Quit();
        }
        [When(@"enter ""(.*)"" under Record opening date")]
        public void WhenEnterUnderRecordOpeningDate(string specificDate)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("opening-date-filters")).Click();
            // _driver.FindElement(By.XPath("//a[contains(text(),'Record opening date')]")).Click();
            _driver.FindElement(By.XPath("//*[@id='recordOpeningDate']/label")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//*[@id='rodDate']")).SendKeys(specificDate);
            _driver.FindElement(By.Name("Refine record opening date")).Click();
        }

        [Then(@"click on the first record and check the record opening date should be ""(.*)""")]
        public void ThenClickOnTheFirstRecordAndCheckTheRecordOpeningDateShouldBe(string specificDate)
        {
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualOpeningDate = trRecordOpeningDate.FindElement(By.TagName("td")).Text;

            DateTime recordDate = DateTime.Parse(actualOpeningDate);

            DateTime specificDateFormat = DateTime.Parse(specificDate);
            //DateTime nowDate = DateTime.Now;
            //DateTime yesterday = nowDate.AddDays(-1);

            Assert.IsTrue(specificDateFormat == recordDate);
            _driver.Quit();
        }
        [When(@"enter ""(.*)"", ""(.*)"" for date range under Record opening date")]
        public void WhenEnterForDateRangeUnderRecordOpeningDate(string fromDate, string toDate)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1700)");
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("opening-date-filters")).Click();
            // _driver.FindElement(By.XPath("//a[contains(text(),'Record opening date')]")).Click();
            _driver.FindElement(By.XPath("//*[@id='recordOpeningDateRange']/label[1]")).Click();
            _driver.FindElement(By.XPath("//*[@id='rodfromdate']")).SendKeys(fromDate);
            _driver.FindElement(By.XPath("//*[@id='rodtodate']")).SendKeys(toDate);
            _driver.FindElement(By.Name("Refine record opening date")).Click();
        }

        [Then(@"click on the first record and check the record opening date should be with in the range ""(.*)"", ""(.*)""")]
        public void ThenClickOnTheFirstRecordAndCheckTheRecordOpeningDateShouldBeWithInTheRange(string fromDate, string toDate)
        {
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualOpeningDate = trRecordOpeningDate.FindElement(By.TagName("td")).Text;

            DateTime recordDate = DateTime.Parse(actualOpeningDate);

            DateTime fromDateFormat = DateTime.Parse(fromDate);
            DateTime toDateFormat = DateTime.Parse(toDate);

            Assert.IsTrue((recordDate <= toDateFormat) && (recordDate >= fromDateFormat));
            _driver.Quit();
        }
        [When(@"enter ""(.*)"", I am under Records tab check for the filter Dates unknown")]
        public void WhenEnterIAmUnderRecordsTabCheckForTheFilterDatesUnknown(string word)
        {
           _driver.FindElement(By.Id("search-for")).SendKeys(word);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            string recordsFilters = _driver.FindElement(By.Id("search-filters")).Text;
            Assert.IsTrue(recordsFilters.Contains("Dates unknown"));
        }
        [Then(@"I am under record creators tab check for the filter Dates unknown")]
        public void ThenIAmUnderRecordCreatorsTabCheckForTheFilterDatesUnknown()
        {
            _driver.FindElement(By.Id("name-authorities-tab")).Click();
            string recordCreatorsFilters = _driver.FindElement(By.ClassName("available-filters")).Text;
            Assert.IsTrue(recordCreatorsFilters.Contains("Dates unknown"));
            _driver.Quit();
        }


    }
}
