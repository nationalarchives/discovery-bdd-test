using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class AdvancedSearch_Records
    {
        public IWebDriver _driver;
        
        [Given(@"Open chrome and Navigate to Discovery Advanced Search")]
        public void GivenOpenChromeAndNavigateToDiscoveryAdvancedSearch()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
            _driver.FindElement(By.XPath("//a[contains(text(),'Advanced search')]")).Click();
        }

        [When(@"enter ""(.*)"" and click on other archives and I typed ""(.*)"" and click on Collection held privately enquiries to Gloucestershire Archives")]
        public void WhenEnterAndClickOnOtherArchivesAndITypedAndClickOnCollectionHeldPrivatelyEnquiriesToGloucestershireArchives(string word, string keyword)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.Id("search-other-repositories")).Click();
            _driver.FindElement(By.Id("repositories-lookup")).SendKeys(keyword);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement L = _driver.FindElement(By.XPath("(//ul[@class='ui-autocomplete ui-front ui-menu ui-widget ui-widget-content ui-corner-all'])[1]/li"));
            Thread.Sleep(2000);
            L.Click();
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }

        [Then(@"I can see the filters Other archives and Gloucestershire Archives")]
        public void ThenICanSeeTheFiltersOtherArchivesAndGloucestershireArchives()
        {
            string filters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(filters);
            Assert.IsTrue((filters.Contains("Gloucestershire Archives")) && (filters.Contains("Other archives")));
            _driver.Close();
        }

        [When(@"enter ""(.*)"" and click on TNA and enter ""(.*)"" and I click on AX Local Government Boundary Commission for England")]
        public void WhenEnterAndClickOnTNAAndEnterAndIClickOnAXLocalGovernmentBoundaryCommissionForEngland(string word, string key)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.Id("search-tna-as-repository")).Click();
            _driver.FindElement(By.Id("departments-lookup")).SendKeys(key);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement list = _driver.FindElement(By.XPath("(//ul[@class='ui-autocomplete ui-front ui-menu ui-widget ui-widget-content ui-corner-all'])[3]/li"));
            list.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string actual = _driver.FindElement(By.XPath("//*[@id='departments']/div[2]/label")).Text;
            Console.WriteLine(actual);
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }
        [Then(@"I can see the filters The national archives and filters with gov")]
        public void ThenICanSeeTheFiltersTheNationalArchivesAndFiltersWithGov()
        {
            string yourfilters = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue((yourfilters.Contains("Gov")) && (yourfilters.Contains("The National Archives")));
            _driver.Quit();
        }
        [When(@"typed ""(.*)"" and click on TNA and click on all records")]
        public void WhenTypedAndClickOnTNAAndClickOnAllRecords(string word)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1100)");
            _driver.FindElement(By.Id("search-tna-as-repository")).Click();
            _driver.FindElement(By.Id("col0")).Click();
        }

        [When(@"enter (.*) for on a specific date and click on closed Document And check for the filters TNA and Closed Document and click on the first record")]
        public void WhenEnterForOnASpecificDateAndClickOnClosedDocumentAndCheckForTheFiltersTNAAndClosedDocumentAndClickOnTheFirstRecord(string date)
        {
            _driver.FindElement(By.Id("rodDate")).SendKeys(date);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            //js.ExecuteScript("window.scrollTo(0, 2200)");
            _driver.FindElement(By.Id("cs-C")).Click();
            // click on search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
            string yourfilters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(yourfilters);
            Assert.IsTrue((yourfilters.Contains("The National Archives")) && (yourfilters.Contains("Closed Document")));
            _driver.FindElement(By.XPath("//ul[@id='search-results']/li[1]")).Click();
        }
        [When(@"I click on specific date and typed (.*) and click on Open Document and check for the filters TNA and Open Document and click on the first record")]
        public void WhenIClickOnSpecificDateAndTypedAndClickOnOpenDocumentAndCheckForTheFiltersTNAAndOpenDocumentAndClickOnTheFirstRecord(string date)
        {
            _driver.FindElement(By.Id("rodDate")).SendKeys(date);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 2100)");
            _driver.FindElement(By.Id("cs-O")).Click();
            // click on search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
            string yourfilters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(yourfilters);
            Assert.IsTrue((yourfilters.Contains("The National Archives")) && (yourfilters.Contains("Open Document")));
            _driver.FindElement(By.XPath("//ul[@id='search-results']/li[1]")).Click();
        }


        [Then(@"Check for (.*) Records Opening Date is same as above")]
        public void ThenCheckForRecordsOpeningDateIsSameAsAbove(DateTime date)
        {
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Record opening date:"));
            var actualText = trRecordOpeningDate.FindElement(By.TagName("td")).Text;
            if (DateTime.TryParse(actualText, out DateTime actualDate))
            {
                Assert.AreEqual(actualDate, date);
            }
            else
            {
                Assert.Fail("Invalid date!!!!");
            }
            _driver.Quit();

        }
        [When(@"typed ""(.*)"" and click on TNA and click on all records and on partially open checkbox under Record closure status")]
        public void WhenTypedAndClickOnTNAAndClickOnAllRecordsAndOnPartiallyOpenCheckboxUnderRecordClosureStatus(string word)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.Id("search-tna-as-repository")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.Id("col0")).Click();
            js.ExecuteScript("window.scrollTo(0, 1500)");
            js.ExecuteScript("window.scrollTo(0, 2100)");
            _driver.FindElement(By.Id("cs-P")).Click();
            // click on search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }

        [Then(@"Check for the filter Partially Open and zero Records")]
        public void ThenCheckForTheFilterPartiallyOpenAndZeroRecords()
        {
            string yourfilters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(yourfilters);
            Assert.IsTrue((yourfilters.Contains("The National Archives")) && (yourfilters.Contains("Partially Open")));
            // check for 'Records 0'
            string Recordsfilters = _driver.FindElement(By.Id("records-tab")).Text;
            Console.WriteLine(Recordsfilters);
            Assert.IsTrue(Recordsfilters.Contains("Records 0"));
            _driver.Close();
        }
        [When(@"typed ""(.*)"" and click on TNA and click on all records and click on Retained Document under Record closure status")]
        public void WhenTypedAndClickOnTNAAndClickOnAllRecordsAndClickOnRetainedDocumentUnderRecordClosureStatus(string word)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.Id("search-tna-as-repository")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.Id("col0")).Click();
            js.ExecuteScript("window.scrollTo(0, 1500)");
            js.ExecuteScript("window.scrollTo(0, 2100)");
            _driver.FindElement(By.Id("cs-R")).Click();
            // click on search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }

        [When(@"Check for the filter Retained Document and click on the first record")]
        public void WhenCheckForTheFilterRetainedDocumentAndClickOnTheFirstRecord()
        {
            string yourfilters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(yourfilters);
            Assert.IsTrue((yourfilters.Contains("The National Archives")) && (yourfilters.Contains("Retained Document")));
            _driver.FindElement(By.XPath("//ul[@id='search-results']/li[1]")).Click();
        }

        [Then(@"check for the closure status: Retained Document")]
        public void ThenCheckForTheClosureStatusRetainedDocument()
        {
            var trRecordOpeningDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Closure status:"));
            var actualStatus = trRecordOpeningDate.FindElement(By.TagName("td")).Text;
            Assert.IsTrue(actualStatus.Contains("Retained Document"));
            _driver.Quit();
        }
        [When(@"enter these ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void WhenEnterTheseAnd(string AllOfTheseWords, string AnyOfTheseWords, string FromDate, string ToDate)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(AllOfTheseWords);
            _driver.FindElement(By.Id("any-words-records-one")).SendKeys(AnyOfTheseWords);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 700)");
            _driver.FindElement(By.Id("from-date")).SendKeys(FromDate);
            _driver.FindElement(By.Id("to-date")).SendKeys(ToDate);
            // click on search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }
        [Then(@"check the third record is in the range ""(.*)"" and ""(.*)""")]
        public void ThenCheckTheThirdRecordIsInTheRangeAnd(string strFromDate, string strToDate)
        {
            DateTime fromDate;
            DateTime toDate;

            // strFromDate could be 1900 09/1900

            if (!DateTime.TryParse(strFromDate, out fromDate))
            {
                int year;
                
                if(!Int32.TryParse(strFromDate, out year))
                {
                    //Do somethinng.
                    throw  new ApplicationException("Not a vlaid format!");
                }
                else
                {
                    fromDate = new DateTime(year, 1, 1);
                }
            }
            

            if (!DateTime.TryParse(strToDate, out toDate))
            {
                int year;
                if (!Int32.TryParse(strToDate, out year))
                {
                    //Do somethinng.
                    throw new ApplicationException("Not a vlaid format!");
                }
                else
                { 
                    toDate = new DateTime(year, 1, 1);
                }
            }
            // click on the second record
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[2]/a")).Click();
            var trDateRange = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Date:"));
            var actualDate = trDateRange.FindElement(By.TagName("td")).Text;
            if ((actualDate.Contains("-"))&&(actualDate.Length >= 13))
            {
                var strActualFromDateRecords = actualDate.Split('-').First();
                var strActualToDateRecords = actualDate.Split('-').Last();
                DateTime recordFromDate = Convert.ToDateTime(strActualFromDateRecords);
                DateTime recordToDate = Convert.ToDateTime(strActualToDateRecords);
                //Assert.IsTrue(recordFromDate >= fromDate);
                //Assert.IsTrue(recordFromDate.Year >= fromDate.Year);

                Assert.IsTrue(((recordFromDate >= fromDate) && (recordFromDate <= toDate)) || ((recordToDate >= fromDate) && (recordToDate <= toDate)));

            }
            else
            if(((actualDate.Contains("-")) && ((actualDate.Length >= 7) && (actualDate.Length <= 12))))
            {
                int intFromDate = Int32.Parse(strFromDate);
                int intToDate = Int32.Parse(strToDate);
                string recordStrFromDate = actualDate.Split('-').First();
                string recordStrToDate = actualDate.Split('-').Last();
                int recordFromDate = Int32.Parse(strFromDate);
                int recordToDate = Int32.Parse(strToDate);

                Assert.IsTrue(((recordFromDate >= intFromDate) && (recordFromDate <= intToDate)) || ((recordToDate >= intFromDate) && (recordToDate <= intToDate)));
            }
            else
            {
                string recordStrDate = actualDate.Substring(actualDate.Length - 5);
                int recordIntDate = Int32.Parse(recordStrDate);
                // DateTime recordDate = Convert.ToDateTime(recordIntDate);
                Assert.IsTrue((recordIntDate >= fromDate.Year) && (recordIntDate <= toDate.Year));
            }
            _driver.Quit();

        }

        [Then(@"check all the records contains ""(.*)"" and ""(.*)""")]
        public void ThenCheckAllTheRecordsContainsAnd(string AllOfTheseWords, string AnyOfTheseWords)
        {
            string actual = _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Text;
            Assert.IsTrue((actual.Contains(AllOfTheseWords)) || (actual.Contains(AnyOfTheseWords)));

        }
        [When(@"check all the Catalogue levels and Exclude title")]
        public void WhenCheckAllTheCatalogueLevelsAndExcludeTitle()
        {
            _driver.FindElement(By.Id("catLvl-1")).Click();
            _driver.FindElement(By.Id("catLvl-2")).Click();
            _driver.FindElement(By.Id("catLvl-3")).Click();
            _driver.FindElement(By.Id("catLvl-6")).Click();
            _driver.FindElement(By.Id("catLvl-7")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 2000)");
            // click on exclude title
            _driver.FindElement(By.Id("notitlesearch")).Click();
            // click on search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }
        [Then(@"the records shouldn't be zero")]
        public void ThenTheRecordsShouldnTBeZero()
        {
            string records = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreNotEqual(records,"Records 0");
            _driver.Quit();
        }
        [When(@"typed ""(.*)"", enter ""(.*)"", click on TNA, click on All records, click on Include content")]
        public void WhenTypedEnterClickOnTNAClickOnAllRecordsClickOnIncludeContent(string word, string SearchForReferences)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            _driver.FindElement(By.Id("reference-search-0")).SendKeys(SearchForReferences);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.Id("search-tna-as-repository")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.FindElement(By.Id("col0")).Click();
            js.ExecuteScript("window.scrollTo(0, 2000)");
            // click on include content
            _driver.FindElement(By.Id("includecontent")).Click();
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();

        }

        [Then(@"check for the filter ""(.*)""")]
        public void ThenCheckForTheFilter(string SearchForReferences)
        {
            // check filter
            string filters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(filters);
            Assert.IsTrue(filters.Contains(SearchForReferences));
            // check reference is same
            string reference = _driver.FindElement(By.XPath("//ul[@id='search-results']/li[1]")).Text;
            Assert.IsTrue(reference.Contains(SearchForReferences));
            // check records shouldn't be zero
            string records = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreNotEqual(records, "Records 0");
            _driver.Quit();
        }
        [When(@"typed ""(.*)"", click on TNA, Click on All records and click on Witchcraft")]
        public void WhenTypedClickOnTNAClickOnAllRecordsAndClickOnWitchcraft(string word)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            _driver.FindElement(By.Id("search-tna-as-repository")).Click();
            _driver.FindElement(By.Id("col0")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 4100)");
            _driver.FindElement(By.Id("C10117")).Click();
            // search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }

        [Then(@"check the third record contains witchcraft")]
        public void ThenCheckTheThirdRecordContainsWitchcraft()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            var results = _driver.FindElements(By.XPath("//*[@id='search-results']/li"));
            if (results.Count > 2)
            {
                var trSubjects = results[2].FindElements(By.TagName("tr")).FirstOrDefault(x => x.Text.Contains("Subjects:"));
                var actualSubjects = trSubjects.FindElement(By.TagName("td")).Text;
                Assert.IsTrue(actualSubjects.Contains("Witchcraft"));
            }
            else
            {
                Assert.Fail();
            }
            _driver.Quit();
        }

        [When(@"typed ""(.*)"" , ""(.*)"", ""(.*)""")]
        public void WhenTyped(string AllOfTheseWords, string AnyOfTheseWords, string SpecificDate)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(AllOfTheseWords);
            _driver.FindElement(By.Id("any-words-records-one")).SendKeys(AnyOfTheseWords);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.Id("search-specific-date")).Click();
            _driver.FindElement(By.Id("from-date")).SendKeys(SpecificDate);
            // search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();

        }

        [Then(@"check for the filter contains ""(.*)""")]
        public void ThenCheckForTheFilterContains(string SpecificDate)
        {
            string filters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(filters);
            Assert.IsTrue(filters.Contains(SpecificDate));
        }

        [Then(@"check the second record contains ""(.*)"" , ""(.*)""")]
        public void ThenCheckTheSecondRecordContains(string AllOfTheseWords, string AnyOfTheseWords)
        {
            string secondRecord = _driver.FindElement(By.XPath("//ul[@id='search-results']/li[2]")).Text;
            Assert.IsTrue((secondRecord.Contains(AllOfTheseWords))&& (secondRecord.Contains(AnyOfTheseWords)));
            _driver.Quit();
        }
        [When(@"enter ""(.*)""")]
        public void WhenEnter(string Reference)
        {
            _driver.FindElement(By.Id("reference-search-0")).SendKeys(Reference);
            // search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }

        [Then(@"check in the third record for ""(.*)""")]
        public void ThenCheckInTheThirdRecordFor(string Reference)
        {
            var results = _driver.FindElements(By.XPath("//*[@id='search-results']/li"));
            if (results.Count > 2)
            {
                var trReference = results[2].FindElements(By.TagName("tr")).FirstOrDefault(x => x.Text.Contains("Reference:"));
                var actualReference = trReference.FindElement(By.TagName("td")).Text;
                Assert.IsTrue(actualReference.Contains(Reference));
            }
            else
            {
                Assert.Fail();
            }
            _driver.Quit();
        }
        [When(@"enter ""(.*)"",""(.*)"" and Search")]
        public void WhenEnterAndSearch(string AllOfTheseWords, string exactWordOrPhase)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(AllOfTheseWords);
            _driver.FindElement(By.Id("exact-words-records")).SendKeys(exactWordOrPhase);
            // search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();

        }

        [Then(@"I should see the ""(.*)""")]
        public void ThenIShouldSeeThe(string exactWordOrPhase)
        {
           string actual = _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Text;
            Assert.IsTrue(actual.Contains(exactWordOrPhase));

        }

        [When(@"I click on AdvancedSearch again and enter ""(.*)""")]
        public void WhenIClickOnAdvancedSearchAgainAndEnter(string dontFindAnyOfTheseWords)
        {
            _driver.FindElement(By.LinkText("Advanced search")).Click();
            _driver.FindElement(By.Id("not-words-records-one")).SendKeys(dontFindAnyOfTheseWords);
            // search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();
        }

        [Then(@"I shouldn't see ""(.*)""")]
        public void ThenIShouldnTSee(string dontFindAnyOfTheseWords)
        {
            string actual = _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Text;
            Assert.IsFalse(actual.Contains(dontFindAnyOfTheseWords));
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"" and click on other archives")]
        public void WhenIEnterAndClickOnOtherArchives(string word)
        {
            _driver.FindElement(By.Id("all-words-records")).SendKeys(word);
            _driver.FindElement(By.Id("search-other-repositories")).Click();
            // search
            _driver.FindElements(By.XPath("//input[@type='submit' and @value='Search']")).FirstOrDefault().Click();

        }

        [Then(@"I should see the filter Other Archives and Records shouldn't be zero")]
        public void ThenIShouldSeeTheFilterOtherArchivesAndRecordsShouldnTBeZero()
        {
            string yourFilters = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue(yourFilters.Contains("Other archives"));
            string numberOfRecords = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreNotEqual(numberOfRecords, "Records 0");
            _driver.Quit();
        }
       
    }
}
