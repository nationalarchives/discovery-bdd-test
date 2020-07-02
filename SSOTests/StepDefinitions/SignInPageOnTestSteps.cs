using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SSOTests.StepDefinitions
{
    [Binding]
    public class SignInPageOnTestSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on home page and click on signin")]
        public void GivenIAmOnHomePageAndClickOnSignin()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
            _driver.FindElement(By.Id("signin")).Click();

        }

        [When(@"I enter only ""(.*)"" without username and trying to signin")]
        public void WhenIEnterOnlyWithoutUsernameAndTryingToSignin(string pswd)
        {
            _driver.FindElement(By.Id("Password")).SendKeys(pswd);
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
        }

        [Then(@"I should see the validation message Please enter your email address")]
        public void ThenIShouldSeeTheValidationMessagePleaseEnterYourEmailAddress()
        {
            string validationMsg = _driver.FindElement(By.CssSelector(".field-validation-error")).Text;
            Assert.AreEqual(validationMsg, "Please enter your email address.");
            _driver.Close();
        }
        [When(@"I enter only ""(.*)"" without password and trying to signin")]
        public void WhenIEnterOnlyWithoutPasswordAndTryingToSignin(string email)
        {

            _driver.FindElement(By.Id("UserName")).SendKeys(email);
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
        }

        [Then(@"I should see the validation message Please enter your password")]
        public void ThenIShouldSeeTheValidationMessagePleaseEnterYourPassword()
        {
            string validationMsg = _driver.FindElement(By.CssSelector(".field-validation-error")).Text;
            Assert.AreEqual(validationMsg, "Please enter your password.");
            _driver.Close();
        }

        [When(@"I don't enter anything and trying to signin")]
        public void WhenIDonTEnterAnythingAndTryingToSignin()
        {
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
        }

        [Then(@"I should see the validation messages Please enter your email address and Please enter your password")]
        public void ThenIShouldSeeTheValidationMessagesPleaseEnterYourEmailAddressAndPleaseEnterYourPassword()
        {
            string validationMsgEmail = _driver.FindElement(By.CssSelector("p:nth-child(1) > .field-validation-error")).Text;
            Assert.AreEqual(validationMsgEmail, "Please enter your email address.");
            string validationMsgPswd = _driver.FindElement(By.CssSelector("p:nth-child(2) > .field-validation-error")).Text;
            Assert.AreEqual(validationMsgPswd, "Please enter your password.");
            _driver.Close();
        }
        [When(@"I sign in with ""(.*)"" and ""(.*)"" and go to personal details")]
        public void WhenISignInWithAndAndGoToPersonalDetails(string username, string password)
        {
            _driver.FindElement(By.Id("UserName")).SendKeys(username);
            _driver.FindElement(By.Id("Password")).SendKeys(password);
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("signInLink")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.LinkText("Your account")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.LinkText("Your personal details")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"I should see the text Click here to change your password")]
        public void ThenIShouldSeeTheTextClickHereToChangeYourPassword()
        {
            string changePswdTxt = _driver.FindElement(By.LinkText("Click here to change your password")).Text;
            Assert.AreEqual(changePswdTxt, "Click here to change your password");
            _driver.Close();
        }


    }
}
