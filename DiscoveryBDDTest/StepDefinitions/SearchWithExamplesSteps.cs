using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class SearchWithExamplesSteps : SearchSteps
    {
        
        [When(@"I enter (.*)")]
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
            _driver.Close();
        }
    }
}
