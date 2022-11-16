using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Nunit_NetCore
{
    [Binding]
    public class PageNavigator
    {
        public IConfiguration Configuration { get; set; }

        public String baseUrl;

        public PageNavigator()
        {
            var configurationBuilder = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
            baseUrl = Configuration.GetValue<string>("baseUrl");

        }
        public IWebDriver OpenChromeAndNavigateTo(string url)
        {
            var path = Configuration.GetValue<string>("googleDriverPath");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(path, "chromedriver.exe");
            var _driver = new ChromeDriver(service);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(url);
            return _driver;
        }
        public IWebDriver GoToNRARedirectsPage()
        {
            var path = Configuration.GetValue<string>("NRARedirects");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToA2ARedirectsPage()
        {
            var path = Configuration.GetValue<string>("A2ARedirects");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToReaderTicketDemoPage()
        {
            var url = Configuration.GetValue<string>("readerTicketDemoPageUrl");
            return OpenChromeAndNavigateTo(url);
        }
        public IWebDriver GoToNRAPdfDownloadPage()
        {
            var path = Configuration.GetValue<string>("NRAPdfDownload");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToNRAPdfDownloadAnotherIAIDPage()
        {
            var path = Configuration.GetValue<string>("NRAPDFDownloadAnother");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToDiscoveryHomePage()
        {
            var path = Configuration.GetValue<string>("discoveryPath");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToFOIRegisterPage()
        {
            var path = Configuration.GetValue<string>("FOI1939Register");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }

        public IWebDriver GoToNewFOIRegisterPage()
        {
            var path = Configuration.GetValue<string>("1939RegisterFOI");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }

        public IWebDriver GoToManorSearchPage()
        {
            var path = Configuration.GetValue<string>("manorSearch");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToFindAnArchivePage()
        {
            var path = Configuration.GetValue<string>("findAnArchive");
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToFOIRequestPage(string iaId)
        {
            var path = string.Format(Configuration.GetValue<string>("FOIRequest"), iaId);
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToPageCheckRequestPage(string iaId)
        {
            var path = string.Format(Configuration.GetValue<string>("pageCheckRequest"), iaId);
            return OpenChromeAndNavigateTo(baseUrl + path);
        }

        public IWebDriver GoToDiscoveryDetailsPage(string recordType, string Iaid)
        {
            var path = string.Format(Configuration.GetValue<string>("discoveryDetailsPath"), recordType, Iaid);
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToDiscoveryDeliveryOptionsPage(string recordType, string iaId)
        {
            var path = string.Format(Configuration.GetValue<string>("discoveryDeliveryOptionsStaffinPath"), recordType, iaId);
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToDetailsPageOffsite(string recordType, string iaId)
        {
            var path = string.Format(Configuration.GetValue<string>("offsiteDetailsPath"), recordType, iaId);
            return OpenChromeAndNavigateTo(baseUrl + path);
        }
        public IWebDriver GoToCabinetPaperSearchPage()
        {
            var url = Configuration.GetValue<string>("cabinetPapersUrl");
            return OpenChromeAndNavigateTo(url);
        }
        public IWebDriver GoToSingleSignOnPage()
        {
            var url = Configuration.GetValue<string>("singleSignOnUrl");
            return OpenChromeAndNavigateTo(url);
        }
        public void SingleSignOn(IWebDriver driver)
        {
            var username = Configuration.GetValue<string>("username");
            var password = Configuration.GetValue<string>("password");

            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.ClassName("singleColumnSubmit")).Click();
        }


    }

}