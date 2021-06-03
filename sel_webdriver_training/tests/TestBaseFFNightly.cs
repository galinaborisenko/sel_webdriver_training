using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace litecart
{
    public class TestBaseFFNightly
    {
        public IWebDriver driver;
        public ChromeOptions options;

        [SetUp]
        public void StartBrowser()
        {
            //старая схема for FF Nightly or FF 
            FirefoxOptions options = new FirefoxOptions
            {
                UseLegacyImplementation = false,
                BrowserExecutableLocation = @"C:\Program Files\Firefox Nightly\firefox.exe"
            };
            driver = new FirefoxDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void StopBrowser()
        {
            driver.Quit(); //close browser window
            driver = null;
        }


    }
}
