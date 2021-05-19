using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;


namespace sel_webdriver_training
{
    [TestFixture]
    public class MyTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void FirstTest()
        {
            driver.Url = "https://www.google.com/";
            driver.FindElement(By.Id("L2AGLb")).Click();
            driver.FindElement(By.Name("q")).SendKeys("webdriver" + Keys.Enter);
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit(); //close browser window
            driver = null;
        }
    }
}

