using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace litecart
{
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Start()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void Login()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit(); //close browser window
            driver = null;
        }

    }
}
