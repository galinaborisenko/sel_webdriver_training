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

namespace litecart
{
    public class Task14 : TestBase
    {
        [Test]
        public void WindowsTest()
        {
            navigationHelper.GoToAdminHomePage();
            loginHelper.LoginAdmin();
            navigationHelper.GoToAdminCountriesPage();
            driver.FindElement(By.CssSelector(".button[href*=edit]"));
            //запоминаем id текущего окна
            string mainWindow = driver.CurrentWindowHandle;
            //запоминаем ids текущих окон
            ICollection<string> oldWindows = driver.WindowHandles;
            // открывает новое окно
            IWebElement link = driver.FindElement(By.CssSelector(".fa.fa-external-link"));
            link.Click();

           


        }
    }
}
