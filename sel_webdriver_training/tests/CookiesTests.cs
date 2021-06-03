using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace litecart
{
    public class CookiesTests
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {          
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]

        public void Cookies() {
           
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.Manage().Cookies.AddCookie(new Cookie("test", "test"));
            Cookie testCookie = driver.Manage().Cookies.GetCookieNamed("test");
            ICollection<Cookie> cookies = driver.Manage().Cookies.AllCookies;
            driver.Manage().Cookies.DeleteCookieNamed("test");
            driver.Manage().Cookies.DeleteAllCookies();
        }
        

        [TearDown]
        public void StopBrowser()
        {
            driver.Quit(); //close browser window
            driver = null;
        }


    }
}
