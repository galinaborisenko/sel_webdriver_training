using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace litecart
{
    public class Task171

    {
        private IWebDriver driver;

        [SetUp]
        public void Start()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }




        [Test]
        public void Test()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";

            driver.FindElement(By.Id("box-login")).FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("login")).Click();

            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";

            List<string> productLinks = new List<string>();

            IList<IWebElement> hrefs = driver.FindElements(By.XPath("//tr[@class = 'row']//a[contains(@href, 'product_id') and @title='Edit']"));

            foreach (IWebElement href in hrefs)
            {
                productLinks.Add(href.GetAttribute("href"));
            }

            foreach (string link in productLinks)
            {
                driver.Url = link;
                //var logs = driver.Manage().Logs.GetLog("browser");
                foreach (LogEntry log in driver.Manage().Logs.GetLog("browser"))
                {
                    Console.WriteLine(log);
                    Assert.IsEmpty(log.ToString());
                }
            }
        }



        [TearDown]
        public void StopBrowser()
        {
            driver.Quit(); //close browser window
            driver = null;
        }

    }
}
