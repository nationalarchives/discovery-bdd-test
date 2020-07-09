using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DiscoveryBDDTest.StepDefinitions
{
    [Binding]
    public class RegisterPageSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on Registration page")]
        public void GivenIAmOnRegistrationPage()
        {
            _driver = new PageNavigator().GoToSingleSignOnPage();
        }

        [When(@"I click on Register without entering anything")]
        public void WhenIClickOnRegisterWithoutEnteringAnything()
        {
            _driver.FindElement(By.XPath("//input[@value='Register']")).Click();
        }

        [Then(@"I can see validation messages")]
        public void ThenICanSeeValidationMessages()
        {
            string accountCreation = _driver.FindElement(By.XPath("//div[@class='validation-summary-errors']/span")).Text;
            string emailField = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[1]")).Text;
            string confirmationEmailField = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[2]")).Text;
            string pswdField = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[3]")).Text;
            string confirmationPswdField = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[4]")).Text;
            string termsConditions = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[5]")).Text;

            Assert.AreEqual("Account creation was unsuccessful. Please correct the errors and try again.", accountCreation);
            Assert.AreEqual("The Email field is required.", emailField);
            Assert.AreEqual("The ConfirmEmail field is required.", confirmationEmailField);
            Assert.AreEqual("The Password field is required.", pswdField);
            Assert.AreEqual("The ConfirmPassword field is required.", confirmationPswdField);
            Assert.AreEqual("You must accept the terms and conditions.", termsConditions);
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" in registration page")]
        public void WhenIEnterInRegistrationPage(string name, string email, string confirmEmail, string pswd, string confirmPswd)
        {
            _driver.FindElement(By.Id("Name")).SendKeys(name);
            _driver.FindElement(By.Id("Email")).SendKeys(email);
            _driver.FindElement(By.Id("ConfirmEmail")).SendKeys(confirmEmail);
            _driver.FindElement(By.Id("Password")).SendKeys(pswd);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmPswd);
            _driver.FindElement(By.Id("tcLabel")).Click();
            _driver.FindElement(By.XPath("//input[@value='Register']")).Click();

        }
        [Then(@"I should see the ""(.*)"" if ""(.*)"",""(.*)"" mismatch")]
        public void ThenIShouldSeeTheIfMismatch(string emailValidationMessage, string email, string confirmEmail)
        {
            if (email != confirmEmail)
            {
                string accCreationErrors = _driver.FindElement(By.XPath("//div[@class='validation-summary-errors']/span")).Text;
                Assert.AreEqual(accCreationErrors, "Account creation was unsuccessful. Please correct the errors and try again.");

                string emailErrors = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[1]")).Text;
                Assert.AreEqual(emailErrors, emailValidationMessage);
            }
        }

        [Then(@"I should see ""(.*)"" if ""(.*)"",""(.*)"" mismatch in registration page")]
        public void ThenIShouldSeeIfMismatchInRegistrationPage(string pswdValidationMessage, string pswd, string confirmPswd)
        {
            if (pswd != confirmPswd)
            {
                string accCreationErrors = _driver.FindElement(By.XPath("//div[@class='validation-summary-errors']/span")).Text;
                Assert.AreEqual(accCreationErrors, "Account creation was unsuccessful. Please correct the errors and try again.");

                string emailErrors = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[1]")).Text;
                Assert.AreEqual(emailErrors, pswdValidationMessage);
            }
            _driver.Quit();
        }
        [Then(@"I should see ""(.*)""")]
        public void WhenIShouldSee(string verifyEmailMsg)
        {
            Thread.Sleep(1000);
            string welcomeMessage = _driver.FindElement(By.XPath("//div[@class='heading-holding-banner']")).Text;
            Assert.AreEqual(welcomeMessage, verifyEmailMsg);
        }
        [When(@"signin with ""(.*)"",""(.*)"", go to your personal details, change email ""(.*)""")]
        public void WhenSigninWithGoToYourPersonalDetailsChangeEmail(string oldId, string oldPswd, string newEmail)
        {
            _driver.FindElement(By.LinkText("Sign in")).Click();
            _driver.FindElement(By.Id("UserName")).SendKeys(oldId);
            _driver.FindElement(By.Id("Password")).SendKeys(oldPswd);
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
            //var webDriver = new PageNavigator();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            //js.ExecuteScript("window.scrollTo(0, 400)");
            //webDriver.SingleSignOn(_driver);
            _driver.FindElement(By.LinkText("Your personal details")).Click();
            _driver.FindElement(By.Id("Email")).Clear();
            _driver.FindElement(By.Id("Email")).SendKeys(newEmail);
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.XPath("//input[@value='Save details']")).Click();
            Thread.Sleep(1000);
        }
       
        [When(@"signin with ""(.*)"", ""(.*)""")]
        public void WhenSigninWith(string newEmail, string oldPswd)
        {

            _driver.FindElement(By.Id("UserName")).SendKeys(newEmail);
            _driver.FindElement(By.Id("Password")).SendKeys(oldPswd);
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
            Thread.Sleep(1000);
            //string welcomeMessage = _driver.FindElement(By.XPath("//div[@class='heading-holding-banner']")).Text;
            //Assert.AreEqual(welcomeMessage, verifyEmailMsg);
        }

        [When(@"for change password go to your personal details, change password")]
        public void WhenForChangePasswordGoToYourPersonalDetailsChangePassword()
        {
            _driver.FindElement(By.LinkText("Your personal details")).Click();
            _driver.FindElement(By.LinkText("Click here to change your password")).Click();
        }
        [When(@"for change password enter  ""(.*)"",""(.*)"",""(.*)""")]
        public void WhenForChangePasswordEnter(string oldPswd, string newPassword, string confirmNewPassword)
        {
            _driver.FindElement(By.Id("OldPassword")).SendKeys(oldPswd);
            _driver.FindElement(By.Id("NewPassword")).SendKeys(newPassword);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmNewPassword);
            _driver.FindElement(By.XPath("//input[@name='SavePassword']")).Click();
            Thread.Sleep(1000);
            string changePswdMessage = _driver.FindElement(By.XPath("//div[@class='updateSuccess']")).Text;
            Assert.AreEqual(changePswdMessage, "Your password has been successfully updated");
            _driver.FindElement(By.LinkText("Sign out")).Click();
        }

        [Then(@"sign in using ""(.*)"",""(.*)""")]
        public void ThenSignInUsing(string newEmail, string newPassword)
        {
            _driver.FindElement(By.Id("UserName")).SendKeys(newEmail);
            _driver.FindElement(By.Id("Password")).SendKeys(newPassword);
            _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"delete the account and check for ""(.*)""")]
        public void ThenDeleteTheAccountAndCheckFor(string accountDeletionMessage)
        {
            _driver.FindElement(By.LinkText("Delete your account")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@value='Confirm account deletion']")).Click();
            Thread.Sleep(1000);
            string changePswdMessage = _driver.FindElement(By.XPath("//div[@class='grid-within-grid-two-item']")).Text;
            Assert.IsTrue(changePswdMessage.Contains(accountDeletionMessage));
            _driver.Quit();
        }
        [When(@"click on signin, forgotten your password, enter ""(.*)""")]
        public void WhenClickOnSigninForgottenYourPasswordEnter(string email)
        {
            _driver.FindElement(By.LinkText("Sign in")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.LinkText("Forgotten your password?")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Email")).SendKeys(email);
            _driver.FindElement(By.XPath("//input[@value='Send request']")).Click();
            Thread.Sleep(1000);

        }

        [Then(@"check for the reset your password message")]
        public void ThenCheckForTheResetYourPasswordMessage()
        {
            string resetPswd = _driver.FindElement(By.XPath("//div[@class='heading-holding-banner']")).Text;
            Assert.IsTrue(resetPswd.Contains("Reset your password"));
            string chkEmail = _driver.FindElement(By.XPath("//div[@class='container row']")).Text;
            Assert.IsTrue(chkEmail.Contains("Check your e-mail "));
            _driver.Quit();
        }
        [When(@"I enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" but don't tick T&C and register")]
        public void WhenIEnterButDonTTickTCAndRegister(string name, string email, string confirmEmail, string pswd, string confirmPswd)
        {
            _driver.FindElement(By.Id("Name")).SendKeys(name);
            _driver.FindElement(By.Id("Email")).SendKeys(email);
            _driver.FindElement(By.Id("ConfirmEmail")).SendKeys(confirmEmail);
            _driver.FindElement(By.Id("Password")).SendKeys(pswd);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmPswd);
            _driver.FindElement(By.XPath("//input[@value='Register']")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"check for the validation message You must accept the terms and conditions")]
        public void ThenCheckForTheValidationMessageYouMustAcceptTheTermsAndConditions()
        {
            string accCreation = _driver.FindElement(By.XPath("//div[@class='validation-summary-errors']/span")).Text;
            Assert.IsTrue(accCreation.Contains("Account creation was unsuccessful. Please correct the errors and try again."));

            string termsConditions = _driver.FindElement(By.XPath("(//span[@class='field-validation-error'])[1]")).Text;
            Assert.IsTrue(termsConditions.Contains("You must accept the terms and conditions."));
            _driver.Quit();
        }



    }
}
