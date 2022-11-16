using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class BookmarkOnTestSteps 
    {
        public IWebDriver _driver;

        [Given(@"I signed in and navigate to details page for (.*)")]
        public void GivenISignedInAndNavigateToDeyailsPageFor(string Iaid)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDetailsPage("r", Iaid);
            _driver.FindElement(By.Id("signin")).Click();
            webDriver.SingleSignOn(_driver);
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
        [When(@"I click on bookmark link and add the bookmark")]
        public void WhenIClickOnBookmarkLinkAndAddTheBookmark()
        {
            _driver.FindElement(By.LinkText("Bookmark")).Click();
            _driver.FindElement(By.XPath("//input[@name='title']")).SendKeys("Testbookmark");
            _driver.FindElement(By.XPath("//input[@value='Add bookmark']")).Click();

        }

        [Then(@"check for the bookmarks successfully added or not")]
        public void ThenCheckForTheBookmarksSuccessfullyAddedOrNot()
        {
            string actualMessage = _driver.FindElement(By.Id("bookmarkAddedSuccessfully")).Text;
            Assert.AreEqual("Bookmark has been added successfully", actualMessage);
        }

        [Then(@"Rename, delete the bookmark, check for the delete messages")]
        public void ThenRenameDeleteTheBookmarkCheckForTheDeleteMessages()
        {
            _driver.FindElement(By.Id("signInLink")).Click();
            _driver.FindElement(By.LinkText("Your bookmarks")).Click();
            _driver.FindElement(By.LinkText("Your bookmarks")).Click();
            _driver.FindElement(By.LinkText("Rename")).Click();
            _driver.FindElement(By.XPath("//input[@name='newTitle']")).SendKeys("TestRenamebookmark");
            _driver.FindElement(By.XPath("//input[@value='Confirm']")).Click();
            _driver.FindElement(By.LinkText("Delete")).Click();
            _driver.FindElement(By.LinkText("Confirm")).Click();
            string actualDeleteMessage = _driver.FindElement(By.XPath("//div[@class='col ends-at-two-thirds box']/h2")).Text;
            Assert.AreEqual("You currently have no bookmarked pages", actualDeleteMessage);
            _driver.Quit();
        }
       

    }
}
