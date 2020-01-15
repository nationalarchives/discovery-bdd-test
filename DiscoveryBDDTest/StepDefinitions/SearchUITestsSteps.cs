using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class SearchUITestsSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on search UI home page")]
        public void GivenIAmOnSearchUIHomePage()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
        }
        
        [When(@"I enter ""(.*)"" and ""(.*)"" on home page")]
        public void WhenIEnterAndOnHomePage(string invalidFromYear, string invalidToYear)
        {
            _driver.FindElement(By.XPath("//*[@id='start-date']")).SendKeys(invalidFromYear);
            _driver.FindElement(By.XPath("//*[@id='end-date']")).SendKeys(invalidToYear);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
        
        [Then(@"I can see validation messages to enter correct format for start and end dates")]
        public void ThenICanSeeValidationMessagesToEnterCorrectFormatForStartAndEndDates()
        {
            string validationMsg = _driver.FindElement(By.ClassName("Headline")).Text;
            Assert.AreEqual("You have entered invalid date formats for the start and end dates. Please use the format DD/MM/YYYY or MM/YYYY or YYYY.",
               validationMsg);
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"" for from year on home page")]
        public void WhenIEnterForFromYearOnHomePage(string invalidFromYear)
        {
            _driver.FindElement(By.XPath("//*[@id='start-date']")).SendKeys(invalidFromYear);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I can see validation messages to enter correct format for start dates")]
        public void ThenICanSeeValidationMessagesToEnterCorrectFormatForStartDates()
        {
            string validationMsg = _driver.FindElement(By.ClassName("Headline")).Text;
            Assert.AreEqual("You have entered an invalid date format for the start date. Please use the format DD/MM/YYYY or MM/YYYY or YYYY.",
               validationMsg);
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"" for to year on home page")]
        public void WhenIEnterForToYearOnHomePage(string invalidToYear)
        {
            _driver.FindElement(By.XPath("//*[@id='end-date']")).SendKeys(invalidToYear);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I can see validation messages to enter correct format for end dates")]
        public void ThenICanSeeValidationMessagesToEnterCorrectFormatForEndDates()
        {
            string validationMsg = _driver.FindElement(By.ClassName("Headline")).Text;
            Assert.AreEqual("You have entered an invalid date format for the start date. Please use the format DD/MM/YYYY or MM/YYYY or YYYY.",
               validationMsg);
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"" and ""(.*)"" for between fields")]
        public void WhenIEnterAndForBetweenFields(string from, string to)
        {
            _driver.FindElement(By.XPath("//*[@id='start-date']")).SendKeys(from);
            _driver.FindElement(By.XPath("//*[@id='end-date']")).SendKeys(to);
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
        [Then(@"I should see the results in the range ""(.*)"" ""(.*)""")]
        public void ThenIShouldSeeTheResultsInTheRange(string from, string to)
        {
            // check filter
            string chkFilter = _driver.FindElement(By.XPath("//*[@id='search-refine']/ul/li[1]/span")).Text;
            Assert.IsTrue((chkFilter.Contains(from)) && (chkFilter.Contains(to)));
            if (from.Contains("/")&&(to.Length==4))
            {
                int fromDate = Int32.Parse(from.Substring(from.Length - 4));
                int toDate = Int32.Parse(to);
                // check the first record
                _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
                var trDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Date:"));
                var actualDate = trDate.FindElement(By.TagName("td")).Text;
                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 22))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            else
            if (to.Contains("/")&&from.Length==4)
            {
                int fromDate = Int32.Parse(from);
                int toDate = Int32.Parse(to.Substring(to.Length - 4));
                // check the first record
                _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
                var trDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Date:"));
                var actualDate = trDate.FindElement(By.TagName("td")).Text;
                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 20))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
           else
            if (from.Contains("/") && (to.Contains("/")))
            {
                int fromDate = Int32.Parse(from.Substring(from.Length - 4));
                int toDate = Int32.Parse(to.Substring(to.Length - 4));            
                // check the first record
                _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
                var trDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Date:"));
                var actualDate = trDate.FindElement(By.TagName("td")).Text;
                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 22))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            if ((from.Length==4) && (to.Length == 4))
            {
                int fromDate = Int32.Parse(from);
                int toDate = Int32.Parse(to);
                // check the first record
                _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
                var trDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Date:"));
                var actualDate = trDate.FindElement(By.TagName("td")).Text;
                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 22))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"", ""(.*)"" archives")]
        public void WhenIEnterArchives(string word, string heldBy)
        {
            _driver.FindElement(By.Id("search-for")).SendKeys(word);

            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("held-by")));
            oSelect.SelectByText(heldBy);

        }

        [Then(@"I should see ""(.*)"",""(.*)""")]
        public void ThenIShouldSee(string word, string heldBy)
        {
            string results = _driver.FindElement(By.Id("search-results")).Text;
            Assert.IsTrue(results.Contains(word));
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]/a")).Click();
            var trHeldby = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Held by:"));
            var actualHeldBy = trHeldby.FindElement(By.TagName("td")).Text;
            if (heldBy == "Other archives only")
            {
                Assert.AreNotEqual(actualHeldBy, "The National Archives, Kew");
            }
            else
            {
                Assert.AreEqual(actualHeldBy, "The National Archives, Kew");
            }
        }
        [Then(@"I should see the date in the range ""(.*)"" ""(.*)""")]
        public void ThenIShouldSeeTheDateInTheRange(string from, string to)
        {
            var trDate = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Date:"));
            var actualDate = trDate.FindElement(By.TagName("td")).Text;

            if (from.Contains("/") && (to.Length == 4))
            {
                int fromDate = Int32.Parse(from.Substring(from.Length - 4));
                int toDate = Int32.Parse(to);

                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 22))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            else
            if (to.Contains("/") && from.Length == 4)
            {
                int fromDate = Int32.Parse(from);
                int toDate = Int32.Parse(to.Substring(to.Length - 4));

                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 20))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            else
            if (from.Contains("/") && (to.Contains("/")))
            {
                int fromDate = Int32.Parse(from.Substring(from.Length - 4));
                int toDate = Int32.Parse(to.Substring(to.Length - 4));

                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 22))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            if ((from.Length == 4) && (to.Length == 4))
            {
                int fromDate = Int32.Parse(from);
                int toDate = Int32.Parse(to);

                if (actualDate.Length == 4)
                {
                    int intYear = Int32.Parse(actualDate);
                    Assert.IsTrue((intYear >= fromDate) && (intYear <= toDate));
                }
                else if ((actualDate.Length <= 11) && (actualDate.Contains("-")))
                {
                    int fromRecordDate = Int32.Parse(actualDate.Substring(0, 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
                else if ((actualDate.Length >= 11) && (actualDate.Length <= 22))
                {
                    int Year = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((Year >= fromDate) && (Year <= toDate));
                }
                else if ((actualDate.Length >= 22) && (actualDate.Contains("-")))
                {
                    string fromDateBeforeHyphen = actualDate.Split("\\-")[0];

                    int fromRecordDate = Int32.Parse(fromDateBeforeHyphen.Substring(fromDateBeforeHyphen.Length - 4));
                    int toRecordDate = Int32.Parse(actualDate.Substring(actualDate.Length - 4));
                    Assert.IsTrue((fromRecordDate >= fromDate && fromRecordDate <= toDate) || (toRecordDate >= fromDate && toRecordDate <= toDate) || (fromDate >= fromRecordDate && toDate <= toRecordDate));
                }
            }
            _driver.Quit();
        }
        [When(@"I search without entering anything in the fields")]
        public void WhenISearchWithoutEnteringAnythingInTheFields()
        {
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I should see validation message")]
        public void ThenIShouldSeeValidationMessage()
        {
            string validationMessage = _driver.FindElement(By.ClassName("Headline")).Text;
            Assert.AreEqual(validationMessage, "Enter a keyword or catalogue reference to start your search");
            _driver.Quit();
        }
        

    }
}
