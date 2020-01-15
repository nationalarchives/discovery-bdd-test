using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class DetailPageOnTestSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on details page for ""(.*)""")]
        public void GivenIAmOnDetailsPageFor(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);

        }

        [When(@"click on NO for could this page be improved\?")]
        public void WhenClickOnNOForCouldThisPageBeImproved()
        {
            _driver.FindElement(By.XPath("//div[@id='details-feedback-wrapper']/div/form/fieldset/button")).Click();
        }

        [When(@"check for the title Your feedback helps us improve our services\. Please share any comments below \(optional\)\.")]
        public void WhenCheckForTheTitleYourFeedbackHelpsUsImproveOurServices_PleaseShareAnyCommentsBelowOptional_()
        {
            string feedbackTitle = _driver.FindElement(By.XPath("//*[@id='no_fieldset']/div/label")).Text;
            Assert.AreEqual(feedbackTitle, "Your feedback helps us improve our services. Please share any comments below (optional).");
        }

        [When(@"click on send")]
        public void WhenClickOnSend()
        {
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"check for the title Thank you for your feedback")]
        public void ThenCheckForTheTitleThankYouForYourFeedback()
        {
            string verifyTitle = _driver.FindElement(By.XPath("//*[@id='details-feedback-wrapper']/div/p")).Text;
            Assert.AreEqual(verifyTitle, "Thank you for your feedback");
            _driver.Quit();
        }
        [When(@"click on YES for could this page be improved\?")]
        public void WhenClickOnYESForCouldThisPageBeImproved()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 700)");
            _driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            Thread.Sleep(3000);
        }

        [When(@"click on ""(.*)"" under please let us know why you are dissatisfied")]
        public void WhenClickOnUnderPleaseLetUsKnowWhyYouAreDissatisfied(string checkBox)
        {

            _driver.FindElement(By.Id(checkBox)).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 700)");
            Thread.Sleep(3000);
        }
        [When(@"click on ""(.*)"" under catalogue description")]
        public void WhenClickOnUnderCatalogueDescription(string letUsKnow)
        {
            _driver.FindElement(By.Id("show-suggestion-form")).Click();
        }

        [When(@"enter info ""(.*)"",""(.*)"",""(.*)"",""(.*)"" and ""(.*)""")]
        public void WhenEnterInfoAnd(string fieldContainsError, string whatIsTheError, string correctInformation, string name, string email)
        {
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("fieldContainingError")));
            oSelect.SelectByText(fieldContainsError);
            _driver.FindElement(By.Id("whatIsTheError")).SendKeys(whatIsTheError);
            _driver.FindElement(By.Id("whatIsTheRecommendation")).SendKeys(correctInformation);
            _driver.FindElement(By.Id("userName")).SendKeys(name);
            _driver.FindElement(By.Id("userEmail")).SendKeys(email);
            _driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
        }

        [When(@"I enter fieldContainsError ""(.*)""")]
        public void WhenIEnterFieldContainsError(string fieldContainsError)
        {
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("fieldContainingError")));
            oSelect.SelectByText(fieldContainsError);
        }


        [Then(@"check for the message Thank you for taking time to submit a suggestion")]
        public void ThenCheckForTheMessageThankYouForTakingTimeToSubmitASuggestion()
        {
            string verifyMessage = _driver.FindElement(By.XPath("//p[@class='emphasis-block']")).Text;
            Assert.AreEqual(verifyMessage, "Thank you for taking the time to submit a suggestion. "
                + "We may contact you within the next 10 days if we need further information. We will not be able to notify you if "
                + "your suggestions is successful due to the high volume of suggestions we receive. The National Archives appreciates "
                + "all suggestions as each one can help us improve Discovery for everyone.");
            _driver.Quit();
        }
        [Given(@"I am on details page for offsite ""(.*)""")]
        public void GivenIAmOnDetailsPageForOffsite(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDetailsPageOffsite("r", iaId);
        }

        [When(@"click on preview an image of this record")]
        public void WhenClickOnPreviewAnImageOfThisRecord()
        {
            _driver.FindElement(By.LinkText("Preview an image of this record.")).Click();
        }

        [Then(@"check for the title To download this record without a watermark please add it to your basket")]
        public void ThenCheckForTheTitleToDownloadThisRecordWithoutAWatermarkPleaseAddItToYourBasket()
        {
            string title = _driver.FindElement(By.XPath("//div[@id='imageviewerOverlay']")).Text;
            Assert.AreEqual(title, "To download this record without a watermark, please add it to your basket.");
            _driver.FindElement(By.LinkText("Hide images")).Click();
            _driver.Quit();
        }
        [Given(@"I am on details page for staffin ""(.*)""")]
        public void GivenIAmOnDetailsPageForStaffin(string iaId)
        {

            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);
        }

        [Then(@"I shouldn't see the message To download this recordwithout watermark please add it to your basket")]
        public void ThenIShouldnTSeeTheMessageToDownloadThisRecordwithoutWatermarkPleaseAddItToYourBasket()
        {
            string title = _driver.FindElement(By.Id("imageViewerApp")).Text;
            Assert.AreNotEqual(title, "To download this record without a watermark, please add it to your basket.");
            _driver.FindElement(By.LinkText("Hide images")).Click();
            _driver.Quit();
        }
        [When(@"verify the reference On Department level")]
        public void WhenVerifyTheReferenceOnDepartmentLevel()
        {
            string departmentRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(departmentRef.Contains("Reference: T"));
        }

        [When(@"verify the reference on Division level")]
        public void WhenVerifyTheReferenceOnDivisionLevel()
        {
            _driver.FindElement(By.XPath("//a[@href='/browse/r/h/C252']")).Click();
            _driver.FindElement(By.XPath("//a[@href='/details/r/C671']")).Click();
            string divisionRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(divisionRef.Contains("Reference: Division within T"));
        }

        [When(@"verify series level")]
        public void WhenVerifySeriesLevel()
        {
            _driver.FindElement(By.XPath("//a[@href='/browse/r/h/C671']")).Click();
            _driver.FindElement(By.XPath("//a[@href='/details/r/C13807']")).Click();
            string seriesRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(seriesRef.Contains("Reference: T 70"));
        }

        [When(@"verify Subseries level")]
        public void WhenVerifySubseriesLevel()
        {
            _driver.FindElement(By.XPath("//a[@href='/browse/r/h/C13807']")).Click();
            _driver.FindElement(By.XPath("//a[@href='/details/r/C33507']")).Click();
            string subseriesRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(subseriesRef.Contains("Reference: Subseries within T 70"));
        }

        [When(@"verify subsubseries level")]
        public void WhenVerifySubsubseriesLevel()
        {
            _driver.FindElement(By.XPath("//a[@href='/browse/r/h/C33507']")).Click();
            _driver.FindElement(By.XPath("//a[@href='/details/r/C100324']")).Click();
            string subsubseriesRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(subsubseriesRef.Contains("Reference: Subsubseries within T 70"));
        }

        [Then(@"I shouls verify Piece level and item level")]
        public void ThenIShoulsVerifyPieceLevelAndItemLevel()
        {
            _driver.FindElement(By.XPath("//a[@href='/browse/r/h/C100324']")).Click();
            _driver.FindElement(By.XPath("//a[@href='/details/r/C1248122']")).Click();
            string pieceRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(pieceRef.Contains("Reference: T 70/1142"));
            _driver.FindElement(By.XPath("//a[@href='/browse/r/h/C1248122']")).Click();
            _driver.FindElement(By.XPath("//a[@href='/details/r/C6221775']")).Click();
            string itemRef = _driver.FindElement(By.CssSelector("table.asset-details")).Text;
            Assert.IsTrue(itemRef.Contains("Reference: T 70/1142"));
        }

        [When(@"I enter info")]
        public void WhenIEnterInfo(Table table)
        {

            _driver.FindElement(By.Id("whatIsTheError")).SendKeys(table.Rows[0]["whatIsTheError"]);
            _driver.FindElement(By.Id("whatIsTheRecommendation")).SendKeys(table.Rows[0]["correctInformation"]);
            _driver.FindElement(By.Id("userName")).SendKeys(table.Rows[0]["name"]);
            _driver.FindElement(By.Id("userEmail")).SendKeys(table.Rows[0]["email"]);
            _driver.FindElement(By.XPath("//input[@value='Submit']")).Click();
        }

        [When(@"I enter all these ""(.*)"", ""(.*)""")]
        public void WhenIEnterAllThese(string firstName, string lastName)
        {
            _driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            // search
            _driver.FindElement(By.XPath("(//input[@type='submit'])[3]")).Click();
        }
        [Then(@"check for ""(.*)"",""(.*)"" from the first record and check ""(.*)""")]
        public void ThenCheckForFromTheFirstRecordAndCheck(string firstName, string lastName, string filter)
        {
            string checkFilter = _driver.FindElement(By.Id("search-refine")).Text;
            Assert.IsTrue(checkFilter.Contains(filter));
            string results = _driver.FindElement(By.Id("search-results")).Text;
            Assert.IsTrue((results.Contains(firstName)) && (results.Contains(lastName)));
            _driver.Quit();
        }
        [When(@"I enter charcters in ""(.*)"", ""(.*)""")]
        public void WhenIEnterCharctersIn(string fromDate, string toDate)
        {
            _driver.FindElement(By.Id("fromDate")).SendKeys(fromDate);
            _driver.FindElement(By.Id("endDate")).SendKeys(toDate);
            // search
            _driver.FindElement(By.XPath("(//input[@type='submit'])[3]")).Click();
        }

        [Then(@"check for the validation message You have entered invalid date format")]
        public void ThenCheckForTheValidationMessageYouHaveEnteredInvalidDateFormat()
        {
            string validationMessage = _driver.FindElement(By.ClassName("validation-summary-errors")).Text;
            Assert.AreEqual(validationMessage, "You have entered invalid date formats for the start and end dates. Please use the format DD/MM/YYYY or MM/YYYY or YYYY.");
            _driver.Quit();
        }

    }
}
