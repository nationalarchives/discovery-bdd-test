using System;
using TechTalk.SpecFlow;

namespace KBSTests.StepDefinitions
{
    [Binding]
    public class StandardOrderSteps
    {
        [Given(@"Go to KBS page for standard order")]
        public void GivenGoToKBSPageForStandardOrder()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click on Select a date under book a standard order visit")]
        public void WhenClickOnSelectADateUnderBookAStandardOrderVisit()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click on date in the first row for standard order")]
        public void WhenClickOnDateInTheFirstRowForStandardOrder()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"enter ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" and complete booking for standard order")]
        public void WhenEnterAndCompleteBookingForStandardOrder(string p0, string p1, string p2, string p3, string p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"check the page title, click on Order documents now for standard order")]
        public void ThenCheckThePageTitleClickOnOrderDocumentsNowForStandardOrder()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"enter two document references ""(.*)"",""(.*)"", enter ""(.*)""")]
        public void ThenEnterTwoDocumentReferencesEnter(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
