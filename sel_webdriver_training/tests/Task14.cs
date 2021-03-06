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
            driver.FindElement(By.CssSelector(".button[href*=edit]")).Click();
            //запоминаем id текущего окна
            string mainWindow = driver.CurrentWindowHandle;

            IList<IWebElement> links = driver.FindElements(By.CssSelector(".fa.fa-external-link"));
            foreach (IWebElement link in links)
            {
               //запоминаем ids текущих окон
               //ICollection<string> oldWindows = driver.WindowHandles;
               int previousWinCount = driver.WindowHandles.Count;
               // открывает новое окно
               link.Click();
               // ожидание появления нового окна
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));              
               wait.Until(driver => driver.WindowHandles.Count == (previousWinCount + 1));
               driver.SwitchTo().Window(driver.WindowHandles.Last());
               driver.Close();
               driver.SwitchTo().Window(mainWindow);
            }

        }


        [Test]
        public void AdminPanelOpenCountryTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            driver.FindElement(By.XPath("//a[contains(.,'Add New Country')]")).Click();

            IList<IWebElement> links = driver.FindElements(By.CssSelector("td>a[target=_blank]"));

            foreach (IWebElement link in links)
            {
                string originalWindow = driver.CurrentWindowHandle;
                ICollection<string> oldWindows = driver.WindowHandles;

                link.Click();

                string newWindow = WaitForWindowOtherThan(oldWindows);

                driver.SwitchTo().Window(newWindow);
                driver.Close();

                driver.SwitchTo().Window(originalWindow);
            }
        }

        private string WaitForWindowOtherThan(ICollection<string> oldWindows)
        {
            throw new NotImplementedException();
        }
    }
}
