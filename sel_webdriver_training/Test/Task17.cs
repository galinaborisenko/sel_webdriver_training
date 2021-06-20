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

namespace litecart
{
    public class Task17

    {
        private EventFiringWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Start()
        {
            driver = new EventFiringWebDriver(new FirefoxDriver());
            driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod);
            driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " found");
            driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);
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

            ICollection<IWebElement> products = driver.FindElements(By.ClassName(".row"));
            foreach (IWebElement product in products)
            {
                List<string> hrefs = new List<string>();
                products = driver.FindElements(By.ClassName(".row"));
                IList<IWebElement> cells = product.FindElements(By.CssSelector("td"));
                string href = cells[5].FindElement(By.TagName("a")).GetAttribute("value");
                hrefs.Add(href);
                Console.WriteLine(string.Join(" ", href));
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
