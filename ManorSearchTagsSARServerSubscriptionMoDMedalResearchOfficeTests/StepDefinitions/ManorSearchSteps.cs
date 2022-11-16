using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class ManorSearchSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on manor search page")]
        public void GivenIAmOnManorSearchPage()
        {
            _driver = new PageNavigator().GoToManorSearchPage();
        }
        [Given(@"click on cookies, hide this message")]
        public void GivenClickOnCookiesHideThisMessage()
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("accept_optional_cookies")).Click();
            //_driver.FindElement(By.Id("reject_optional_cookies")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("hide_this_message")).Click();
        }
        [When(@"I go to Search by Manor, enter ""(.*)"" and select ""(.*)""")]
        public void WhenIGoToSearchByManorEnterAndSelect(string manorName, string historicCountry)
        {
            _driver.FindElement(By.Id("manor-name")).SendKeys(manorName);
            SelectElement country = new SelectElement(_driver.FindElement(By.Name("_ocn")));
            country.SelectByValue(historicCountry);
            _driver.FindElement(By.Name("name")).Click();
        }

        [Then(@"check for Records should be zero and Record creators shouldn't be zero")]
        public void ThenCheckForRecordsShouldBeZeroAndRecordCreatorsShouldnTBeZero()
        {
            string records = _driver.FindElement(By.Id("records-tab")).Text;
            Assert.AreEqual(records, "Records 0");
            string recordCreators = _driver.FindElement(By.Id("name-authorities-tab")).Text;
            Assert.AreNotSame(recordCreators, "Record creators 0");
            string filter = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue(filter.Contains("Manor"));
        }
        
        [Then(@"place should be ""(.*)""")]
        public void ThenPlaceShouldBe(string historicCountry)
        {
            var ulPlace = _driver.FindElements(By.ClassName("linkTitle")).FirstOrDefault(x => x.Text.Contains("Place:"));
            var place = ulPlace.FindElement(By.TagName("ul")).Text;
            Assert.IsTrue(place.Contains(historicCountry));
            _driver.Quit();
        }
        [When(@"I go to search for manorial documents, enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void WhenIGoToSearchForManorialDocumentsEnter(string allOfTheseWords, string historicCountry, string typesOfDocument, string from, string to)
        {
            _driver.FindElement(By.Id("search-documents")).Click();
            _driver.FindElement(By.Id("all-words-records")).SendKeys(allOfTheseWords);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            SelectElement hCountry = new SelectElement(_driver.FindElements(By.Name("_ocn"))[1]);
            hCountry.SelectByValue(historicCountry);
            SelectElement typeDocument = new SelectElement(_driver.FindElement(By.Name("_mdt")));
            typeDocument.SelectByValue(typesOfDocument);
            //js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.Id("search-date-range-record")).Click();
            _driver.FindElement(By.Id("rc-from-date")).SendKeys(from);
            _driver.FindElement(By.Id("rc-to-date")).SendKeys(to);
            _driver.FindElement(By.XPath("(//input[@type='submit'])[4]")).Click();
        }
        [Then(@"check for ""(.*)"" in the results and  Date is in the range ""(.*)"",""(.*)"" and record creators shoul be zero")]
        public void ThenCheckForInTheResultsAndDateIsInTheRangeAndRecordCreatorsShoulBeZero(string typesOfDocument, string from, string to)
        {
            string filter = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue((filter.Contains(from)) && (filter.Contains(to)));
            //var pDocType = _driver.FindElements(By.Id("search-results")).FirstOrDefault(x => x.Text.Contains("Document type:"));
            //var docType = pDocType.FindElement(By.TagName("p")).Text;
            string docType = _driver.FindElement(By.Id("search-results")).Text;
            Assert.IsTrue(docType.Contains(typesOfDocument));
            string recordCreators = _driver.FindElement(By.Id("name-authorities-tab")).Text;
            Assert.AreEqual(recordCreators, "Record creators 0");
            _driver.Quit();
        }
    }
}
