using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

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
            driver.Quit();
            driver = null;
        }
    }
}

