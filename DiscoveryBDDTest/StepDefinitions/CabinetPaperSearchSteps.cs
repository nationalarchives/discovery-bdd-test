using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class CabinetPaperSearchSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on cabinetPaperSearch form")]
        public void GivenIAmOnCabinetPaperSearchForm()
        {
            _driver = new PageNavigator().GoToCabinetPaperSearchPage();
            _driver.FindElement(By.ClassName("btn")).Click();
        }
        [When(@"enter ""(.*)"", click on ""(.*)"", ""(.*)"", ""(.*)"" and select document description only")]
        public void WhenEnterClickOnAndSelectDocumentDescriptionOnly(string word, string documentType, string fromDate, string toDate)
        {
            _driver.FindElement(By.Id("all-words")).SendKeys(word);
            _driver.FindElement(By.Id(documentType)).Click();
            _driver.FindElement(By.Id("from-date")).SendKeys(fromDate);
            _driver.FindElement(By.Id("to-date")).SendKeys(toDate);
            _driver.FindElement(By.Id("decsription")).Click();
            // click on search
            _driver.FindElement(By.XPath("(//input[@value='Search'])[1]")).Click();
        }
        [Then(@"check for the filters ""(.*)"" and ""(.*)""")]
        public void ThenCheckForTheFiltersAnd(string fromDate, string toDate)
        {
            string filters = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue( (filters.Contains(fromDate)) && (filters.Contains(toDate)));
            _driver.Quit();
        }

        [When(@"enter ""(.*)"", click on ""(.*)"" and select Document description only")]
        public void WhenEnterClickOnAndSelectDocumentDescriptionOnly(string word, string documentType)
        {
            _driver.FindElement(By.Id("all-words")).SendKeys(word);
            _driver.FindElement(By.Id(documentType)).Click();
            _driver.FindElement(By.Id("decsription")).Click();
            // click on search
            _driver.FindElement(By.XPath("(//input[@value='Search'])[1]")).Click();
        }

        [Then(@"check for the title Return to cabinet papers website")]
        public void ThenCheckForTheTitleReturnToCabinetPapersWebsite()
        {
            string title = _driver.FindElement(By.LinkText("Return to Cabinet Papers website")).Text;
            Assert.AreEqual(title, "Return to Cabinet Papers website");
            _driver.Quit();
        }
        [When(@"click on Education resources tab, enter ""(.*)""")]
        public void WhenClickOnEducationResourcesTabEnter(string word)
        {
            _driver.FindElement(By.LinkText("Education resources")).Click();
            _driver.FindElement(By.Id("search-all-collections")).SendKeys(word);
            //click on search
            _driver.FindElement(By.XPath("(//input[@value='Search'])[2]")).Click();
        }
        [When(@"enter ""(.*)"" , ""(.*)"" and click on entire document")]
        public void WhenEnterAndClickOnEntireDocument(string word, string filterByDocumentType)
        {

            _driver.FindElement(By.Id("all-words")).SendKeys(word);
            _driver.FindElement(By.Id(filterByDocumentType)).Click();
            _driver.FindElement(By.Id("whole")).Click();
            // click on search
            _driver.FindElement(By.XPath("(//input[@value='Search'])[1]")).Click();
        }
        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    _driver.Quit();
        //}

    }
}
