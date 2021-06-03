using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace litecart 
{
    [TestFixture]
    public class MyTests : TestBase
    {

        [Test]
        public void FirstTest()
        {
            driver.Url = "https://www.google.com/";
            driver.FindElement(By.Id("L2AGLb")).Click();
            driver.FindElement(By.Name("q")).SendKeys("webdriver" + Keys.Enter);
        }
    }
}

