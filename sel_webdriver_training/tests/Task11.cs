using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace litecart
{
    public class Task11 : TestBase
    {
        [Test]
        public void CustomerLoginLogout()
        {
            string email = RandomString(10) +"@test.com";
            navigationHelper.GoToShopHomePage();
            driver.FindElement(By.CssSelector("#box-account-login a[href*=\"create_account\"]")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys("Halyna");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).SendKeys("Bor");
            driver.FindElement(By.Name("address1")).Click();
            driver.FindElement(By.Name("address1")).SendKeys("address1");
            driver.FindElement(By.Name("postcode")).Click();
            driver.FindElement(By.Name("postcode")).SendKeys("11111");
            driver.FindElement(By.Name("city")).Click();
            driver.FindElement(By.Name("city")).SendKeys("NY");
            IWebElement drpCountry = driver.FindElement(By.Name("country_code"));
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].selectedIndex = 224; arguments[0].dispatchEvent(new Event('change'))", drpCountry);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("phone")).Click();
            driver.FindElement(By.Name("phone")).SendKeys(Keys.Home + "+14842634723");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("1111");
            driver.FindElement(By.Name("confirmed_password")).Click();
            driver.FindElement(By.Name("confirmed_password")).SendKeys("1111");
            driver.FindElement(By.Name("create_account")).Click();
            
            driver.FindElement(By.CssSelector("a[href*=\"logout\"]")).Click();
           
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).SendKeys("1111");
            driver.FindElement(By.Name("login")).Click();

            driver.FindElement(By.CssSelector("a[href*=\"logout\"]")).Click();

        }
    }
}
