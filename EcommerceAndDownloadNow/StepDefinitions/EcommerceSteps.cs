using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;



namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class EcommerceSteps
    {
        private string Image1Path;
        private string Image2Path;

        public IWebDriver _driver;
        [Given(@"I am on eCommerce page for ""(.*)""")]
        public void GivenIAmOnECommercePageFor(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDetailsPageOffsite("r", iaId);
        }
        [Given(@"I am on eCommerce page for to upload death certificate ""(.*)""")]
        public void GivenIAmOnECommercePageForToUploadDeathCertificate(string iaId)
        {
            var pageNavigator = new PageNavigator();
            _driver = pageNavigator.GoToDetailsPageOffsite("r", iaId);
            Image2Path = pageNavigator.Configuration.GetValue<string>("Image2Path");
        }

        [Given(@"Request a copy, add to basket, checkout and signed in")]
        public void GivenRequestACopyAddToBasketCheckoutAndSignedIn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.LinkText("Request a copy")).Click();
            Thread.Sleep(1000);
            // click Yes, I would like a certified copy
            _driver.FindElement(By.XPath("//a[@class='discoveryPrimaryCallToActionLink']")).Click();
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollTo(0, 600)");
            // click add to basket
            _driver.FindElement(By.XPath("//input[@class='text_sketch']")).Click();
            Thread.Sleep(1000);
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Checkout']")).Click();
            Thread.Sleep(1000);
            var webDriver = new PageNavigator();
           // _driver.FindElement(By.Id("signin")).Click();
            webDriver.SingleSignOn(_driver);
        }

        [When(@"click on proceed, T&C, pay through paypal")]
        public void WhenClickOnProceedTCPayThroughPaypal()
        {
            //_driver.FindElement(By.LinkText("Add delivery address?")).Click();
            //Thread.Sleep(1000);
            //_driver.FindElement(By.Id("FirstName")).SendKeys("Test");
            //_driver.FindElement(By.Id("Surname")).SendKeys("SurTester");
            //_driver.FindElement(By.Id("HouseNameNo")).SendKeys("99");
            //_driver.FindElement(By.Id("Street")).SendKeys("High street");
            //_driver.FindElement(By.Id("Town")).SendKeys("London");
            //_driver.FindElement(By.Id("PostCode")).SendKeys("TW9 4AD");
            //_driver.FindElement(By.XPath("//input[@type='submit' and @value='Save']")).Click();
           
            _driver.FindElement(By.XPath("//input[@value='Proceed']")).Click();
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.XPath("(//input[@name='termsAndConditionsAccepted'])[1]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("(//input[@type='submit'])[3]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("(//input[@type='image'])[1]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector("#PMMakePayment")).Click();

        }
        
        [Then(@"I should see Thank you for your order")]
        public void ThenIShouldSeeThankYouForYourOrder()
        {
            Thread.Sleep(2000);
            string strPageTitle = _driver.Title;
            Assert.IsTrue(strPageTitle.Contains("Thank you for your order"));
            string recieptMsg = _driver.FindElement(By.Id("orderReference")).Text;
            Assert.IsTrue(recieptMsg.Contains("The order receipt has been sent to"));

            //_driver.Close();
        }
        [Then(@"sign in now")]
        public void ThenSignInNow()
        {
            _driver.FindElement(By.Id("signin")).Click();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
            Thread.Sleep(2000);
            string strPageTitle = _driver.Title;
            Assert.IsTrue(strPageTitle.Contains("Thank you for your order"));
            _driver.Quit();
        }

        [When(@"add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept")]
        public void WhenAddToBasketGoToBasketViewbasketCheckoutEnterEmailAddressUnderSendAReciept()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
             // _driver.FindElement(By.XPath("//input[@type='submit' and @value='Add to basket']")).Click();
            _driver.FindElement(By.LinkText("Add to basket")).Click();
            _driver.FindElement(By.Id("miniBasketLink")).Click();
            // click view basket
            _driver.FindElement(By.XPath("//a[@class='discoverySecondaryCallToActionLink']")).Click();
            js.ExecuteScript("window.scrollTo(0, 700)");
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Checkout'] ")).Click();
            _driver.FindElement(By.XPath("//input[@id='DeliveryEmail']")).SendKeys("tnadiscovery100@gmail.com");

        }
        [When(@"scroll down add to basket, go to basket, viewbasket,checkout, enter email address under send a reciept")]
        public void WhenScrollDownAddToBasketGoToBasketViewbasketCheckoutEnterEmailAddressUnderSendAReciept()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 2600)");
            _driver.FindElement(By.XPath("//input[@value='Add to basket']")).Click();
           // _driver.FindElement(By.XPath("//input[@type='submit' and @value='Add to basket']")).Click();
            //_driver.FindElement(By.LinkText("Add to basket")).Click();
            _driver.FindElement(By.Id("miniBasketLink")).Click();
            // click view basket
            _driver.FindElement(By.XPath("//a[@class='discoverySecondaryCallToActionLink']")).Click();
            js.ExecuteScript("window.scrollTo(0, 700)");
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Checkout'] ")).Click();
            _driver.FindElement(By.XPath("//input[@id='DeliveryEmail']")).SendKeys("tnadiscovery100@gmail.com");
        }


        [When(@"T&C, Submit order pay through paypal")]
        public void WhenTCSubmitOrderPayThroughPaypal()
        {
            _driver.FindElement(By.XPath("(//input[@name='termsAndConditionsAccepted'])[1]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("(//input[@type='submit'])[3]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("(//input[@type='image'])[1]")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.CssSelector("#PMMakePayment")).Click();
            

        }
        [Then(@"go to your orders and I can see order number from your orders list")]
        public void ThenGoToYourOrdersAndICanSeeOrderNumberFromYourOrdersList()
        {
            // get the order number 
            string orderNumber = _driver.FindElement(By.Id("orderReference")).Text;
            Assert.IsTrue(orderNumber.Contains("Order number:"));
            
            _driver.FindElement(By.Id("signInLink")).Click();
            _driver.FindElement(By.LinkText("Your orders")).Click();
            Thread.Sleep(2000);
            // var trReference = _driver.FindElements(By.XPath("//table[@class='asset-details']/tbody/tr")).FirstOrDefault(x => x.Text.Contains("Reference:"));
            // var actualReference = trReference.FindElement(By.TagName("td")).Text;

          //  String actual = _driver.FindElement(By.Id("page_wrap")).Text;
            //Assert.IsTrue(actual.Contains(actualReference));
        }

        [Given(@"I am on Request a search of closed records page")]
        public void GivenIAmOnRequestASearchOfClosedRecordsPage()
        {
            var pageNavigator = new PageNavigator();
            _driver = pageNavigator.GoToFOIRegisterPage();
            Image1Path = pageNavigator.Configuration.GetValue<string>("Image1Path");
           
        }

        [When(@"I enter the details ""(.*)"", ""(.*)"",""(.*)"",""(.*)"",""(.*)"", upload proof of identity")]
        public void WhenIEnterTheDetailsUploadProofOfIdentity(string searchFirstName, string searchLastName, string gender, string dOB, string dataSubjectAccess)
        {
            _driver.FindElement(By.Id("firstnames")).SendKeys(searchFirstName);
            
            _driver.FindElement(By.Id("search_lastname")).SendKeys(searchLastName);
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("search_gender")));
            oSelect.SelectByValue(gender);
           
            _driver.FindElement(By.Id("search_dob")).SendKeys(dOB);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 2300)");
            _driver.FindElement(By.Id(dataSubjectAccess)).Click();
            if (dataSubjectAccess == "notSubject")
            {
                _driver.FindElement(By.Name("consentfile")).SendKeys(Image1Path);
            }
            _driver.FindElement(By.Name("proofIDfile")).SendKeys(Image1Path);

        }

        [When(@"I enter contact details ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void WhenIEnterContactDetails(string firstName, string lastName, string email, string confirmEmail, string address, string TownCity, string postcode, string Country)
        {
            _driver.FindElement(By.Id("firstname")).SendKeys(firstName);
            _driver.FindElement(By.Id("lastname")).SendKeys(lastName);
            _driver.FindElement(By.Id("email")).SendKeys(email);

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollTo(0, 5700)");
           // Thread.Sleep(2000);

            _driver.FindElement(By.Id("Confirm")).Click();
           // _driver.FindElement(By.Id("confirmemail")).SendKeys(confirmEmail);
            //_driver.FindElement(By.Id("address1")).SendKeys(address);
            //_driver.FindElement(By.Id("town")).SendKeys(TownCity);
            //_driver.FindElement(By.Id("postcode")).SendKeys(postcode);
            Thread.Sleep(2000);
           // SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("country")));
            //oSelect.SelectByValue(Country);
        }

        [When(@"Submit request")]
        public void WhenSubmitRequest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 3500)");
            //  _driver.FindElement(By.Id("Confirm")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//input[@value='Submit Request']")).Click();
            //  _driver.FindElement(By.CssSelector("/html/body/div[2]/div[2]/div/div/div[2]/div/form/div/p/input")).Click();
           
           // _driver.FindElement(By.ClassName("heading-holding-banner")).Click();
        }

        [Then(@"I can see confirmation page")]
        public void ThenICanSeeConfirmationPage()
        {
            Thread.Sleep(2000);
            String title = _driver.Title;
            Assert.IsTrue(title.Contains("DSA1939Confirmation"));
            _driver.Quit();
        }
        [Given(@"I am on FOI request page for ""(.*)""")]
        public void GivenIAmOnFOIRequestPageFor(string iaId)
        {
            var pageNavigator = new PageNavigator();
            _driver = pageNavigator.GoToFOIRequestPage(iaId);
            Image2Path = pageNavigator.Configuration.GetValue<string>("Image2Path");

           

        }

        [When(@"I upload evidence of death, enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void WhenIUploadEvidenceOfDeathEnter(string firstName, string lastName, string email, string adress1, string townCity, string postcode, string country)
        {
          
            _driver.FindElement(By.XPath("//input[@name='deathCertFile']")).SendKeys(Image2Path);
            _driver.FindElement(By.Id("firstname")).SendKeys(firstName);
            _driver.FindElement(By.Id("lastname")).SendKeys(lastName);
            _driver.FindElement(By.Id("email")).SendKeys(email);
           // _driver.FindElement(By.Id("address1")).SendKeys(adress1);
            //_driver.FindElement(By.Id("town")).SendKeys(townCity);
            //_driver.FindElement(By.Id("postcode")).SendKeys(postcode);
            Thread.Sleep(2000);
           // SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("country")));
            // oSelect.SelectByValue(country);

        }
        [Given(@"I am on page check page for ""(.*)""")]
        public void GivenIAmOnPageCheckPageFor(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToPageCheckRequestPage(iaId);
        }

        [When(@"click on Get started, enter details, add to basket, checkout, signed in")]
        public void WhenClickOnGetStartedEnterDetailsAddToBasketCheckoutSignedIn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 700)");
            _driver.FindElement(By.Id("get-started")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("certified")).Click();
            _driver.FindElement(By.Id("CustomerInstructions")).SendKeys("Test Research");
            js.ExecuteScript("window.scrollTo(0, 1400)");
            _driver.FindElement(By.XPath("//input[@value='Add to basket']")).Click();
            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollTo(0, 700)");

            _driver.FindElement(By.XPath("//input[@value='Checkout']")).Click();
            var webDriver = new PageNavigator();
            // _driver.FindElement(By.Id("signin")).Click();
            webDriver.SingleSignOn(_driver);
        }
        [When(@"click on Get started, enter morethan one thousand characters")]
        public void WhenClickOnGetStartedEnterMorethanOneThousandCharacters()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.Id("get-started")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.Id("certified")).Click();
            _driver.FindElement(By.Id("CustomerInstructions")).SendKeys("Test Research ::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     +"Test Research::: testing for something as always Where possible, "
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible, "
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,"
                                                                     + "Test Research::: testing for something as always Where possible,") ;
            js.ExecuteScript("window.scrollTo(0, 1400)");
            _driver.FindElement(By.XPath("//input[@value='Add to basket']")).Click();
            Thread.Sleep(1000);
        }

        [Then(@"I can see a message Customer Instructions cannot exceed one thousand characters")]
        public void ThenICanSeeAMessageCustomerInstructionsCannotExceedOneThousandCharacters()
        {
            string validationMessage = _driver.FindElement(By.XPath("//span[@class='field-validation-error text-danger']")).Text;
            Assert.IsTrue(validationMessage.Contains("Customer instructions cannot exceed 1000 characters."));
            _driver.Quit();
        }

        [When(@"click on request a search of closed records, enter search details ""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void WhenClickOnRequestASearchOfClosedRecordsEnterSearchDetails(string searchFirstName, string searchLastName, string dOB, string category)
        {
            _driver.FindElement(By.LinkText("Request a search of closed records")).Click();
            _driver.FindElement(By.Id("search_firstnames")).Clear();
            _driver.FindElement(By.Id("search_firstnames")).SendKeys(searchFirstName);
            _driver.FindElement(By.Id("search_lastname")).Clear();
            _driver.FindElement(By.Id("search_lastname")).SendKeys(searchLastName);
            _driver.FindElement(By.Id("search_dob")).Clear();
            _driver.FindElement(By.Id("search_dob")).SendKeys(dOB);

          //  SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("search_category")));
          //  oSelect.SelectByValue(category);

        }
        //[Then(@"I should see the coronavirus update page")]
        //public void ThenIShouldSeeTheCoronavirusUpdatePage()
        //{
        //    string title = _driver.Title;
        //    Assert.IsTrue(title.Contains("The National Archives now open, offering greater access to our collections - The National Archives"));
        //    _driver.Quit();
        //}




    }
}
