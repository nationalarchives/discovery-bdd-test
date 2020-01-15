using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Nunit_NetCore.StepDefinitions
{
    [Binding]
    public class DeliveryOptionsSteps
    {
        public IWebDriver _driver;

        [Given(@"I am on delivery options page for ""(.*)""")]
        public void GivenIAmOnDeliveryOptionsPageFor(string iaId)
        {
            var webDriver = new PageNavigator();
            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("r", iaId);
        }
        [When(@"I click on ""(.*)""")]
        public void WhenIClickOn(string deliveryOptionstoOtherUsers)
        {
            if (!string.IsNullOrWhiteSpace(deliveryOptionstoOtherUsers))
            {
                _driver.FindElement(By.XPath(deliveryOptionstoOtherUsers)).Click();
                Thread.Sleep(2000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(0, 700)");
            }
        }
        [Then(@"check for staffin ""(.*)"" ,""(.*)"" ,""(.*)"",""(.*)""")]
        public void ThenCheckForStaffin(string staffinStringXPath, string staffinAttributes, string deliveryOptionsAttributes, string staffinMessage)
        {
            Thread.Sleep(2000);
            string stringStaffDO = _driver.FindElement(By.XPath(staffinStringXPath)).Text;
            Assert.IsTrue(stringStaffDO.Contains(staffinMessage));
            Thread.Sleep(2000);
            string checkAttribute = _driver.FindElement(By.XPath(staffinStringXPath)).GetAttribute("innerHTML");
            Assert.IsTrue((checkAttribute.Contains(staffinAttributes)) && (checkAttribute.Contains(deliveryOptionsAttributes)));
        }

        [Then(@"check for onsite ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenCheckForOnsite(string onSiteStringXPath, string onSiteAttributes, string deliveryOptionsAttributes, string onsiteMessage)
        {
            if (!string.IsNullOrWhiteSpace(onSiteStringXPath))
            {
                string stringOnSiteDO = _driver.FindElement(By.XPath(onSiteStringXPath)).Text;
                Assert.IsTrue(stringOnSiteDO.Contains(onsiteMessage));
                string checkAttribute = _driver.FindElement(By.XPath(onSiteStringXPath)).GetAttribute("innerHTML");
                Assert.IsTrue((checkAttribute.Contains(onSiteAttributes)) && (checkAttribute.Contains(deliveryOptionsAttributes)));
            }
        }

        [Then(@"check for offsite  ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenCheckForOffsite(string offSiteStringXPath, string offSiteAttributes, string deliveryOptionsAttributes, string offsiteMessage)
        {
            if (!string.IsNullOrWhiteSpace(offSiteStringXPath))
            {
                string stringOnSiteDO = _driver.FindElement(By.XPath(offSiteStringXPath)).Text;
                Assert.IsTrue(stringOnSiteDO.Contains(offsiteMessage));
                string checkAttribute = _driver.FindElement(By.XPath(offSiteStringXPath)).GetAttribute("innerHTML");
                Assert.IsTrue((checkAttribute.Contains(offSiteAttributes)) && (checkAttribute.Contains(deliveryOptionsAttributes)));
            }
        }
        [Then(@"check for the ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void ThenCheckForThe(string staffinButton, string staffinCheckPageTitle, string onsiteButton, string onsiteCheckPageTitle, string offsiteButton,string offsiteCheckPageTitle)
        {
           if(!string.IsNullOrWhiteSpace(staffinButton))
            {
                
                _driver.FindElement(By.LinkText(staffinButton)).Click();
                Thread.Sleep(3000);
                string strPageTitle = _driver.Title;
                Assert.IsTrue(strPageTitle.Contains(staffinCheckPageTitle));
            }
            if (!string.IsNullOrWhiteSpace(onsiteButton))
            {
                _driver.FindElement(By.LinkText(onsiteButton)).Click();
                Thread.Sleep(3000);
                string strPageTitle = _driver.Title;
                Assert.IsTrue(strPageTitle.Contains(onsiteCheckPageTitle));
            }
            if (!string.IsNullOrWhiteSpace(offsiteButton))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("window.scrollTo(0, 800)");
                //string parentWindowHandler = _driver.CurrentWindowHandle;
                //_driver.SwitchTo().Window(parentWindowHandler);
                _driver.FindElement(By.LinkText(offsiteButton)).Click();
                Thread.Sleep(3000);
                string strPageTitle = _driver.Title;
                Assert.IsTrue(strPageTitle.Contains(offsiteCheckPageTitle));
            }
            _driver.Quit();
        }


     
      

      
        ////////        [Given(@"I am on delivery options page for fileAuthority ""(.*)""")]
        ////////        public void GivenIAmOnDeliveryOptionsPageForFileAuthority(string iaId)
        ////////        {
        ////////            var webDriver = new WebDriver();
        ////////            _driver = webDriver.GoToDiscoveryDeliveryOptionsPage("c", iaId);
        ////////        }

        ////////        [When(@"check for the attributes staffin and FileAuthority")]
        ////////        public void WhenCheckForTheAttributesStaffinAndFileAuthority()
        ////////        {
        ////////            string checkAttribute = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])")).GetAttribute("innerHTML");
        ////////            Assert.IsTrue((checkAttribute.Contains("StaffIn")) && (checkAttribute.Contains("FileAuthority")));
        ////////            Thread.Sleep(2000);
        ////////        }

        ////////        [Then(@"I should see This page summarises records created by this Organisation")]
        ////////        public void ThenIShouldSeeThisPageSummarisesRecordsCreatedByThisOrganisation()
        ////////        {
        ////////            string strOnsite = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])")).Text;
        ////////            Assert.IsTrue(strOnsite.Contains("This page summarises records created by this Organisation"));
        ////////        }

        ////////        [Then(@"click on View details of this record creator")]
        ////////        public void ThenClickOnViewDetailsOfThisRecordCreator()
        ////////        {
        ////////            _driver.FindElement(By.ClassName("call-to-action-link")).Click();
        ////////            string strCheck = _driver.FindElement(By.ClassName("asset-details")).Text;
        ////////            Assert.IsTrue(strCheck.Contains("Date:"));
        ////////            _driver.Quit();
        ////////        }
        //        [When(@"check for the attributes staffin and GovtWebArchive")]
        //        public void WhenCheckForTheAttributesStaffinAndGovtWebArchive()
        //        {
        //            string checkAttribute = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])")).GetAttribute("innerHTML");
        //            Assert.IsTrue((checkAttribute.Contains("StaffIn")) && (checkAttribute.Contains("GovtWebArchive")));
        //            Thread.Sleep(2000);
        //        }

        //        [Then(@"I should see This record is held by the UK Government Web Archive\.")]
        //        public void ThenIShouldSeeThisRecordIsHeldByTheUKGovernmentWebArchive_()
        //        {
        //            string strStaff = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])")).Text;
        //            Assert.IsTrue((strStaff.Contains("This record is held by the UK Government Web Archive.")) &&
        //                (strStaff.Contains("Find a link in the catalogue description to the archived website that holds the record.")));
        //            _driver.Quit();
        //        }
        //        [When(@"check for the attributes staffin and InUse")]
        //        public void WhenCheckForTheAttributesStaffinAndInUse()
        //        {
        //            string checkAttribute = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])[1]")).GetAttribute("innerHTML");
        //            Assert.IsTrue((checkAttribute.Contains("StaffIn")) && (checkAttribute.Contains("InUse")));
        //            Thread.Sleep(2000);
        //        }

        //        [Then(@"I should see This record is currently in use")]
        //        public void ThenIShouldSeeThisRecordIsCurrentlyInUse()
        //        {
        //            string strStaff = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])[1]")).Text;
        //            Assert.IsTrue((strStaff.Contains("This record is currently in use")) &&
        //                (strStaff.Contains("Talk to a member of staff to find out when it may be free.")));
        //        }

        //        [Then(@"It should show Order and viewing options like Order in advance and Request a copy for offsite users")]
        //        public void ThenItShouldShowOrderAndViewingOptionsLikeOrderInAdvanceAndRequestACopyForOffsiteUsers()
        //        {
        //            _driver.FindElement(By.XPath("//div[@id='staffViewOfOtherUserDOsWrapper']/a")).Click();
        //            Thread.Sleep(2000);
        //            string checkAttribute = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])[2]")).GetAttribute("innerHTML");
        //            Assert.IsTrue((checkAttribute.Contains("OffSite")) && (checkAttribute.Contains("InUse")));
        //            string strStaff = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])[2]")).Text;
        //            Assert.IsTrue((strStaff.Contains("Ordering and viewing options")) &&
        //                (strStaff.Contains("This record has not been digitised and cannot be downloaded.")));
        //            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        //            js.ExecuteScript("window.scrollTo(0, 700)");
        //            //click on order in advance
        //            _driver.FindElement(By.LinkText("Order in advance")).Click();
        //            Thread.Sleep(4000);
        //           string strTitle = _driver.FindElement(By.Id("main")).Text;
        //           Assert.IsTrue(strTitle.Contains("Order documents in advance"));
        //        }
        //        [When(@"check for the attributes staffin and InvigilationSafeRoom")]
        //        public void WhenCheckForTheAttributesStaffinAndInvigilationSafeRoom()
        //        {
        //            string checkAttribute = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])[1]")).GetAttribute("innerHTML");
        //            Assert.IsTrue((checkAttribute.Contains("StaffIn")) && (checkAttribute.Contains("InUse")));
        //            Thread.Sleep(2000);
        //            string strStaff = _driver.FindElement(By.XPath("(//div[@class='order-option-wrapper'])[1]")).Text;
        //            Assert.IsTrue((strStaff.Contains("You can view this record under supervision in our Invigilation Room")) &&
        //                (strStaff.Contains("Your order will take approximately 45 minutes to be prepared.")));
        //        }

        //        [Then(@"I should see You can view this record under supervision in our Invigilation Room for onsite users")]
        //        public void ThenIShouldSeeYouCanViewThisRecordUnderSupervisionInOurInvigilationRoomForOnsiteUsers()
        //        {
        //            _driver.FindElement(By.XPath("//*[@id='staffViewOfOtherUserDOsWrapper']/a")).Click();
        //            string strOnSite = _driver.FindElement(By.Id("main")).Text;
        //            Assert.IsTrue(strOnSite.Contains("Order documents in advance"));

        //        }

        //        [Then(@"I should see This record can only be seen under supervision at The National Archives for offsite users")]
        //        public void ThenIShouldSeeThisRecordCanOnlyBeSeenUnderSupervisionAtTheNationalArchivesForOffsiteUsers()
        //        {
        //            ScenarioContext.Current.Pending();
        //        }


    }
}
