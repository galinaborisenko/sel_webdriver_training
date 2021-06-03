using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;


namespace litecart
{
    public class LoginTests : TestBase
    {
        

        [Test]
        public void Login()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("login")).Click();
        }

        

    }
}
