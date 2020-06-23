using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class BrowseOnTestSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on the browse page")]
        public void GivenIAmOnTheBrowsePage()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
            _driver.FindElement(By.LinkText("browse")).Click();
        }
        
        [When(@"I click on ""(.*)"" under Browse archives")]
        public void WhenIClickOnUnderBrowseArchives(string alphabet)
        {
            //_driver.FindElement(By.XPath("//a[contains(@href,'/browse/a/"+ alphabet + "')]")).Click();
            _driver.FindElement(By.LinkText(alphabet)).Click();
        }
        
        [Then(@"check for the first title starts with ""(.*)""")]
        public void ThenCheckForFirstTheTitleStartsWith(string alphabet)
        {
            string title = _driver.FindElement(By.XPath("//*[@id='browse-wrapper']/div[1]/ul/li[2]/div[1]/a")).Text;
            Assert.IsTrue(title.StartsWith(alphabet));
            _driver.Quit();
        }
        [When(@"click on ""(.*)""")]
        public void WhenClickOn(string recordCreatorsType)
        {
            _driver.FindElement(By.LinkText(recordCreatorsType)).Click();
        }
        [Then(@"click on the ""(.*)"" under record creators")]
        public void ThenClickOnTheUnderRecordCreators(string alphabet)
        {
            _driver.FindElement(By.LinkText(alphabet)).Click();
        }

        [Then(@"check for the title starts with ""(.*)"",""(.*)""")]
        public void ThenCheckForTheTitleStartsWith(string recordCreatorsType, string alphabet)
        {
            string str_RecCreator = _driver.FindElement(By.ClassName("creator-type")).Text;
            Assert.IsTrue(str_RecCreator.StartsWith(recordCreatorsType));
            _driver.FindElement(By.XPath("//*[@id='search-results']/li[1]")).Click();
            string str_alphabet = _driver.FindElement(By.ClassName("inline")).Text;
            Assert.IsTrue(str_alphabet.StartsWith(alphabet));
            _driver.Quit();
        }
        [When(@"click on ""(.*)"" under Records of other archives")]
        public void WhenClickOnUnderRecordsOfOtherArchives(string letter)
        {
            _driver.FindElement(By.XPath("//a[contains(@href,'/browse/r/" + letter + "')]")).Click();
        }

        [Then(@"check the title starts with ""(.*)""")]
        public void ThenCheckTheTitleStartsWith(string letter)
        {
            string title = _driver.FindElement(By.ClassName("item-title")).Text;
            Assert.IsTrue(title.StartsWith(letter));
            _driver.Quit();
        }
        [When(@"click on ""(.*)"" under Records of the National Archives")]
        public void WhenClickOnUnderRecordsOfTheNationalArchives(string letter)
        {
            _driver.FindElement(By.LinkText(letter)).Click();
        }

        [Then(@"check the second record title starts with ""(.*)""")]
        public void ThenCheckTheSecondRecordTitleStartsWith(string letter)
        {
            string title = _driver.FindElement(By.ClassName("item-reference")).Text;
            Assert.IsTrue(title.StartsWith(letter));
            _driver.Quit();
        }
       

    }
}
