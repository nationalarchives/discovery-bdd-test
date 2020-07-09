using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class TagOnTestSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on discovery details page for staffin ""(.*)"", signed in")]
        public void GivenIAmOnDiscoveryDetailsPageForStaffinSignedIn(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);
            _driver.FindElement(By.Id("signin")).Click();
            webDriver.SingleSignOn(_driver);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");
        }
        [When(@"I enter ""(.*)"", click on Add tag")]
        public void WhenIEnterClickOnAddTag(string tag)
        {
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("tagEntryText")).SendKeys(tag);
            //click add tag
            _driver.FindElement(By.XPath("//input[@value='Add tag']")).Click();
            Thread.Sleep(2000);
        }

        [Then(@"check for the message your tag has been added")]
        public void ThenCheckForTheMessageYourTagHasBeenAdded()
        {
            string actual = _driver.FindElement(By.XPath("//div[@class='emphasis-block']")).Text;
            Assert.IsTrue(actual.Contains("Your tag has been added. Thank you."));
            _driver.Quit();

        }
        [When(@"click on delete tag")]
        public void WhenClickOnDeleteTag()
        {
            _driver.FindElement(By.XPath("//*[@id='tag-list']/li[1]/div/span/span/a")).Click();
            Thread.Sleep(2000);
            _driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }

        [Then(@"check for the message your tag has been deleted")]
        public void ThenCheckForTheMessageYourTagHasBeenDeleted()
        {
            string actual = _driver.FindElement(By.Id("tag-delete-success-message")).Text;
            Assert.IsTrue(actual.Contains("Your tag has been deleted."));
            _driver.Quit();
        }
        [When(@"we add ""(.*)"" couple of times")]
        public void WhenWeAddCoupleOfTimes(string tag)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");
            _driver.FindElement(By.Id("tagEntryText")).SendKeys(tag);
            _driver.FindElement(By.XPath("//input[@value='Add tag']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("tagEntryText")).SendKeys(tag);
            _driver.FindElement(By.XPath("//input[@value='Add tag']")).Click();
        }

        [Then(@"check the message An error occurred when processing your request to add this tag")]
        public void ThenCheckTheMessageAnErrorOccurredWhenProcessingYourRequestToAddThisTag()
        {
            string actual = _driver.FindElement(By.Id("tag-add-failure-message")).Text;
            Assert.IsTrue(actual.Contains("An error occurred when processing your request to add this tag. This may be because it does not comply with tagging guidelines (see link above)."));
            _driver.Quit();
        }
        [Then(@"click on delete tag")]
        public void ThenClickOnDeleteTag()
        {
            _driver.FindElement(By.XPath("//*[@id='tag-list']/li[2]/div/span/span/a")).Click();
            Thread.Sleep(2000);
            _driver.Quit();
        }
        [Given(@"I am on discovery details page for staffin ""(.*)""")]
        public void GivenIAmOnDiscoveryDetailsPageForStaffin(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
        }

        [When(@"click on flag, enter ""(.*)"", ""(.*)"", ""(.*)""")]
        public void WhenClickOnFlagEnter(string reason, string name, string email)
        {
            _driver.FindElement(By.ClassName("flagTagLink")).Click();
            _driver.FindElement(By.Id("Reason")).SendKeys(reason);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 1000)");
            _driver.FindElement(By.XPath("(//input[@id='userName'])[2]")).SendKeys(name);
            _driver.FindElement(By.XPath("(//input[@id='userEmail'])[2]")).SendKeys(email);
            _driver.FindElement(By.XPath("(//input[@value='Submit'])[2]")).Click();

        }

        [Then(@"check for the message Thank you for submitting a tag removal request\. If you left contact details, a member of our team will be in touch soon")]
        public void ThenCheckForTheMessageThankYouForSubmittingATagRemovalRequest_IfYouLeftContactDetailsAMemberOfOurTeamWillBeInTouchSoon()
        {
            string actual = _driver.FindElement(By.XPath("//div[@id='reportTagCompletionMessage']/p[1]")).Text;
            Assert.IsTrue(actual.Contains("Thank you for submitting a tag removal request. If you left contact details, a member of our team will be in touch soon."));
            _driver.Quit();
        }
        [When(@"enter ""(.*)"" from the stop list")]
        public void WhenEnterFromTheStopList(string tag)
        {
            _driver.FindElement(By.Id("tagEntryText")).SendKeys(tag);
            _driver.FindElement(By.XPath("//input[@value='Add tag']")).Click();
            Thread.Sleep(2000);
        }

     

    }
}
