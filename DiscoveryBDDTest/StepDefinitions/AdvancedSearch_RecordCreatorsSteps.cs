using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class AdvancedSearch_RecordCreatorsSteps
    {
        public IWebDriver _driver;
        [Given(@"Navigate to Advanced Search and click on record creators tab")]
        public void GivenNavigateToAdvancedSearchAndClickOnRecordCreatorsTab()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
            _driver.FindElement(By.XPath("//a[contains(text(),'Advanced search')]")).Click();
            _driver.FindElement(By.Id("record-creators-tab")).Click();
        }
        
        [When(@"I enter ""(.*)"" , select ""(.*)"", ""(.*)"" and ""(.*)"" under record creators")]
        public void WhenIEnterSelectAndUnderRecordCreators(string word, string CreatorType, string Category, string SubCategory)
        {
            _driver.FindElement(By.Id("all-words-record-creators")).SendKeys(word);
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("creator-type")));
            oSelect.SelectByText(CreatorType);
            SelectElement oSelect1 = new SelectElement(_driver.FindElement(By.Id("creator-category")));
            oSelect1.SelectByText(Category);
            SelectElement oSelect2 = new SelectElement(_driver.FindElement(By.Id("creator-sub-category")));
            oSelect2.SelectByText(SubCategory);

        }
        
        [When(@"check three date check boxes ""(.*)"",""(.*)"" and ""(.*)""")]
        public void WhenCheckThreeDateCheckBoxesAnd(string date1, string date2, string date3)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 300)");
            var listItems = _driver.FindElements(By.XPath("//ul[@class='date-periods']/li"));
            listItems.FirstOrDefault(x => x.Text.Contains(date1)).FindElement(By.ClassName("checkBox")).Click();
            listItems.FirstOrDefault(x => x.Text.Contains(date2)).FindElement(By.ClassName("checkBox")).Click();
            listItems.FirstOrDefault(x => x.Text.Contains(date3)).FindElement(By.ClassName("checkBox")).Click();
            // click on search
            _driver.FindElement(By.XPath("//input[@name='top-record-creators-advanced-search']")).Click();

        }
        [Then(@"check for all the filters ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void ThenCheckForAllTheFiltersAnd(string CreatorType, string Category, string SubCategory)
        {
            string yourfilters = _driver.FindElement(By.Id("search-refine")).Text;
            Console.WriteLine(yourfilters);
            Assert.IsTrue((yourfilters.Contains(CreatorType))&&(yourfilters.Contains(Category))&& (yourfilters.Contains(SubCategory)));
            string recordCreators = _driver.FindElement(By.Id("name-authorities-tab")).Text;
            Assert.AreNotEqual(recordCreators, "Record creators 0");
           
        }
        [When(@"enter ""(.*)"" and ""(.*)"" for search a date range")]
        public void WhenEnterAndForSearchADateRange(string FromDate, string ToDate)
        {
            _driver.FindElement(By.Id("rc-from-date")).SendKeys(FromDate);
            _driver.FindElement(By.Id("rc-to-date")).SendKeys(ToDate);
            // click on search
            _driver.FindElement(By.XPath("//input[@name='top-record-creators-advanced-search']")).Click();
        }

        [Then(@"check for Description date is in the range ""(.*)"" and ""(.*)""")]
        public void ThenCheckForDescriptionDateIsInTheRangeAnd(string strFromDate, string strToDate)
        {
            DateTime fromDate;
            DateTime toDate;

            if (!DateTime.TryParse(strFromDate, out fromDate))
            {
                int year;

                if (!Int32.TryParse(strFromDate, out year))
                {
                    //Do somethinng.
                    throw new ApplicationException("Not a vlaid format!");
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
            var results = _driver.FindElements(By.XPath("//*[@id='search-results']/li"));
            if (results.Count > 2)
            {
                var ulDate= results[2].FindElements(By.TagName("ul")).FirstOrDefault(x => x.Text.Contains("Date:"));
                string actualDate = ulDate.FindElement(By.TagName("li")).Text;
                if (actualDate.Contains("-"))
                {
                    int intFromDate = Int32.Parse(strFromDate);
                    int intToDate = Int32.Parse(strToDate);
                    string firstHalfOfDate = actualDate.Split('-').First();
                    string recordStrFromDate = firstHalfOfDate.Substring(firstHalfOfDate.Length - 5);
                    string recordStrToDate = actualDate.Split('-').Last();

                   int recordFromDate = Int32.Parse(recordStrFromDate);
                    int recordToDate = Int32.Parse(recordStrToDate);
                   Assert.IsTrue(((recordFromDate >= intFromDate) && (recordFromDate <= intToDate)) || ((recordToDate >= intFromDate) && (recordToDate <= intToDate)));
                }
              else
              {
                    string recordStrDate = actualDate.Substring(actualDate.Length - 5);
                    int recordIntDate = Int32.Parse(recordStrDate);
                   // DateTime recordDate = Convert.ToDateTime(recordIntDate);
                    Assert.IsTrue((recordIntDate >= fromDate.Year) && (recordIntDate <= toDate.Year));
                }
            }
            
            else
            {
                Assert.Fail();
         
            }
            _driver.Quit();
        }
       

    }
}
