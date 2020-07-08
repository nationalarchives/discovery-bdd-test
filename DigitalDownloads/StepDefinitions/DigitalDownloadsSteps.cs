using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace DigitalDownloads.StepDefinitions
{
    [Binding]
    public class DigitalDownloadsSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on digital downloads page ""(.*)""")]
        public void GivenIAmOnDigitalDownloadsPage(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDetailsPageOffsite("r", iaId);
        }
        [Given(@"check ""(.*)"" and sign in to get this free and basketLimitExplanation")]
        public void GivenCheckAndSignInToGetThisFreeAndBasketLimitExplanation(string price)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            string strPrice = _driver.FindElement(By.Id("orderInformation")).Text;
            Assert.IsTrue(strPrice.Contains(price) && strPrice.Contains("sign in to get this free"));
            string strBasketInfo = _driver.FindElement(By.ClassName("basketLimitExplanation")).Text;
            Assert.IsTrue(strBasketInfo.Contains("Order up to 10 items per basket, and up to 50 in a 30 day period"));
        }

        [When(@"I Add to basket, check basket has the ""(.*)""")]
        public void WhenIAddToBasketCheckBasketHasThe(string price)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.ClassName("discoveryPrimaryCallToActionLink")).Click();
            string strBasket = _driver.FindElement(By.Id("miniBasketLink")).Text;
            Assert.IsTrue(strBasket.Contains(price));

        }

        [Then(@"check the ""(.*)"", view your past orders")]
        public void ThenCheckTheViewYourPastOrders(string priceAfterSignedIn)
        {
            string basketPrice = _driver.FindElement(By.Id("miniBasketLink")).Text;
            Assert.IsTrue(basketPrice.Contains(priceAfterSignedIn));
            // click on view your past orders
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("View your past orders")).Click();
            _driver.FindElement(By.Id("miniBasket")).Click();
            _driver.FindElement(By.LinkText("Checkout")).Click();
            _driver.FindElement(By.Id("confirm-terms")).Click();
            _driver.FindElement(By.XPath("//input[@value='Submit order']")).Click();
            string transactionRef = _driver.FindElement(By.Id("orderReference")).Text;
            Assert.IsTrue(transactionRef.Contains("Transaction reference:"));

        }
        [Then(@"check for the message Digital downloads ordered in the last thirty days")]
        public void ThenCheckForTheMessageDigitalDownloadsOrderedInTheLastThirtyDays()
        {
            _driver.FindElement(By.Id("signInLink")).Click();
            _driver.FindElement(By.LinkText("Your orders")).Click();
            string yourOrdersText = _driver.FindElement(By.ClassName("emphasis-block")).Text;
            Assert.IsTrue(yourOrdersText.Contains("Digital downloads ordered in the last 30 days") && yourOrdersText.Contains("The National Archives permits registered users to order and download a reasonable number of documents and has set a maximum order limit of 50 documents in a 30 day period."));
            _driver.Close();
        }



        [When(@"I signed in")]
        public void WhenISignedIn()
        {
            var webDriver = new PageNavigator();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("sign in")).Click();
            webDriver.SingleSignOn(_driver);
        }

        [Then(@"I should see the price should be free")]
        public void ThenIShouldSeeThePriceShouldBeFree()
        {
            string strPrice = _driver.FindElement(By.Id("price")).Text;
            Assert.IsTrue(strPrice.Contains("Free"));
            _driver.Close();
        }
        [When(@"click on View your past orders")]
        public void WhenClickOnViewYourPastOrders()
        {
            _driver.FindElement(By.LinkText("View your past orders")).Click();
        }

        [Then(@"I should be on the your orders page and I can see latest orders")]
        public void ThenIShouldBeOnTheYourOrdersPageAndICanSeeLatestOrders()
        {
            string strYourOrders = _driver.FindElement(By.ClassName("View your past orders")).Text;
            Assert.IsTrue(strYourOrders.Contains("Your orders"));

        }
        [Given(@"I can see the banner")]
        public void GivenICanSeeTheBanner()
        {
            string bannerText = _driver.FindElement(By.Id("notice")).Text;
            Assert.IsTrue(bannerText.Contains("While our Kew site is closed, signed-in users can download digital records for free"));
        }

        [When(@"I click on fair policy link")]
        public void WhenIClickOnFairPolicyLink()
        {
            _driver.FindElement(By.LinkText("Read about our fair use policy and why we are doing this")).Click();

        }

        [Then(@"I should see free access to digital records page")]
        public void ThenIShouldSeeFreeAccessToDigitalRecordsPage()
        {
            string bannerText = _driver.FindElement(By.Id("news-content")).Text;
            Assert.IsTrue(bannerText.Contains("We are making digital records available on our website free of charge for as long as our Kew site is closed to visitors"));
        }

        [Given(@"I am on home page for DD tests")]
        public void GivenIAmOnHomePageForDDTests()
        {
            _driver = new PageNavigator().GoToDiscoveryHomePage();
        }

        //[Given(@"I am on Registration page to create account")]
        //public void GivenIAmOnRegistrationPageToCreateAccount()
        //{
        //    _driver = new PageNavigator().GoToSingleSignOnPage();
        //}

        //[When(@"I enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" tick all T&C's in registration page")]
        //public void WhenIEnterTickAllTCSInRegistrationPage(string name, string email, string confirmEmail, string pswd, string confirmPswd)
        //{
        //    _driver.FindElement(By.Id("Name")).SendKeys(name);
        //    _driver.FindElement(By.Id("Email")).SendKeys(email);
        //    _driver.FindElement(By.Id("ConfirmEmail")).SendKeys(confirmEmail);
        //    _driver.FindElement(By.Id("Password")).SendKeys(pswd);
        //    _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmPswd);
        //    _driver.FindElement(By.Id("tcLabel")).Click();
        //    _driver.FindElement(By.Id("mlLabel")).Click();
        //    _driver.FindElement(By.Id("frLabel")).Click();
        //    _driver.FindElement(By.CssSelector(".submit")).Click();
        //}
        //[Then(@"I should see verify email page")]
        //public void ThenIShouldSeeVerifyEmailPage()
        //{
        //    string verifyPage = _driver.FindElement(By.CssSelector("p:nth-child(1)")).Text;
        //    Assert.IsTrue(verifyPage.Contains("In order to complete your registration we need to verify your email address"));

        //}
        //[Given(@"I am on signin page and signin ""(.*)"",""(.*)""")]
        //public void GivenIAmOnSigninPageAndSignin(string email, string pswd)
        //{
        //    _driver = new PageNavigator().GoToSingleSignOnPage();
        //    _driver.FindElement(By.LinkText("Sign in")).Click();
        //    _driver.FindElement(By.Id("UserName")).SendKeys(email);
        //    _driver.FindElement(By.Id("Password")).SendKeys(pswd);
        //    _driver.FindElement(By.ClassName("singleColumnSubmit")).Click();
        //}

        //[Given(@"I should see ""(.*)"", go to your personal details, change email ""(.*)""")]
        //public void GivenIShouldSeeGoToYourPersonalDetailsChangeEmail(string welcomeMsg, string newEmail)
        //{
        //    Thread.Sleep(1000);
        //    //string welcomeMessage = _driver.FindElement(By.XPath("//div[@class='heading-holding-banner']")).Text;
        //    //Assert.AreEqual(welcomeMessage, welcomeMsg);
        //    //_driver.FindElement(By.Id("signInLink")).Click();
        //    _driver.FindElement(By.LinkText("Your personal details")).Click();
        //    _driver.FindElement(By.Id("Email")).Clear();
        //    _driver.FindElement(By.Id("Email")).SendKeys(newEmail);
        //    _driver.FindElement(By.XPath("//input[@value='Save details']")).Click();
        //    Thread.Sleep(1000);
        //}
        //[Given(@"signin with ""(.*)"", old""(.*)"", I should see ""(.*)""")]
        //public void GivenSigninWithOldIShouldSee(string newEmail, string pswd, string welcomeMsg)
        //{

        //    _driver.FindElement(By.Id("UserName")).SendKeys(newEmail);
        //    _driver.FindElement(By.Id("Password")).SendKeys(pswd);
        //    _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
        //    Thread.Sleep(1000);
        //    string welcomeMessage = _driver.FindElement(By.XPath("//div[@class='heading-holding-banner']")).Text;
        //    Assert.AreEqual(welcomeMessage, welcomeMsg);
        //}
        //[When(@"for changing password go to your personal details, change password")]
        //public void WhenForChangingPasswordGoToYourPersonalDetailsChangePassword()
        //{
        //    _driver.FindElement(By.LinkText("Your personal details")).Click();
        //    _driver.FindElement(By.LinkText("Change your password")).Click();
        //}
        //[When(@"for changing password enter old ""(.*)"",""(.*)"",""(.*)""")]
        //public void WhenForChangingPasswordEnterOld(string pswd, string newPassword, string confirmNewPassword)
        //{
        //    _driver.FindElement(By.Id("OldPassword")).SendKeys(pswd);
        //    _driver.FindElement(By.Id("NewPassword")).SendKeys(newPassword);
        //    _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmNewPassword);
        //    _driver.FindElement(By.XPath("//input[@name='SavePassword']")).Click();
        //    Thread.Sleep(1000);
        //    string changePswdMessage = _driver.FindElement(By.XPath("//div[@class='updateSuccess']")).Text;
        //    Assert.AreEqual(changePswdMessage, "Your password has been successfully updated");
        //    _driver.FindElement(By.LinkText("Sign out")).Click();
        //}
        //[Then(@"sign in using ""(.*)"" and ""(.*)""")]
        //public void ThenSignInUsingAnd(string newEmail, string newPassword)
        //{
        //    _driver.FindElement(By.Id("UserName")).SendKeys(newEmail);
        //    _driver.FindElement(By.Id("Password")).SendKeys(newPassword);
        //    _driver.FindElement(By.XPath("//input[@value='Sign in']")).Click();
        //    Thread.Sleep(1000);
        //}
        //[Then(@"delete account and check for ""(.*)""")]
        //public void ThenDeleteAccountAndCheckFor(string accountDeletionMessage)
        //{
        //    _driver.FindElement(By.LinkText("Delete your account")).Click();
        //    Thread.Sleep(1000);
        //    _driver.FindElement(By.XPath("//input[@value='Confirm account deletion']")).Click();
        //    Thread.Sleep(1000);
        //    string changePswdMessage = _driver.FindElement(By.XPath("//div[@class='grid-within-grid-two-item']")).Text;
        //    Assert.IsTrue(changePswdMessage.Contains(accountDeletionMessage));
        //    _driver.Quit();
        //}
        [When(@"click on register")]
        public void WhenClickOnRegister()
        {
            _driver.FindElement(By.Id("register")).Click();
        }

        [Then(@"I can see Data protection message in the register page")]
        public void ThenICanSeeDataProtectionMessageInTheRegisterPage()
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            string dataProtectionMessage = _driver.FindElement(By.CssSelector(".emphasisBlock")).Text;
            Assert.IsTrue(dataProtectionMessage.Contains("When you sign up to our mailing list you will receive regular email updates and other information we think might interest you. We use an email distribution company to send out these email updates. We will not pass your data on to any other third parties. You can choose to remove your details from our mailing database at any time by following the ‘unsubscribe’ link included in every email that we send you. Please read our privacy notice for further information."));
            _driver.Close();
        }

    }
}
