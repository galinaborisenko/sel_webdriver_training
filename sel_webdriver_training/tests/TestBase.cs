using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Text;
using System.Linq;

namespace litecart
{
    public class TestBase
    {
        public static IWebDriver driver;
        public ChromeOptions options;

        public LoginHelper loginHelper;
        public NavigationHelper navigationHelper;
        public CountryZoneHelper countryZoneHelper;

        public object Thread { get; private set; }

        [SetUp]
        public void StartBrowser()
        {
            /*if (driver != null)
            {
                return;
            }*/
            //driver = new ChromeDriver();


            // Set Chrome options for Advanced Browser Configurations
            //options = new ChromeOptions(); //for browser setup https://peter.sh/experiments/chromium-command-line-switches/
            //options.AddArgument("--start-fullscreen");
            //options.AddArgument("--window-size=1920,1080");

            //Initialize with options
            //driver = new ChromeDriver(options);

            //Init new scheme FF
            driver = new FirefoxDriver(); 
            //Init MsEdge
            //driver = new EdgeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //неявное ожидание, когда не можем найти локатор сразу
            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver);
            countryZoneHelper = new CountryZoneHelper(driver);
        }

        [TearDown]
        public void StopBrowser()
        {
            driver.Quit(); //close browser window
            driver = null;
        }


        //Common methods
        public bool IsElementPresent(By by)
        {
            driver.FindElement(by);
            return true;
        }

        public bool AreElementsPresent(By by) //эта функция ждет указанное в implicit wait время пока не найдет хоть один элемент
        {
            return driver.FindElements(by).Count > 0;
        }

        public void WaitUntilElementVisible(By locator, int timeoutInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                            .Until(drv => IsElementPresent(locator));
        }

        public void WaitUntilElementNotVisible(By searchElementBy, int timeoutInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                            .Until(drv => !IsElementPresent(searchElementBy));
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public void SetDatepicker(IWebDriver driver, string cssSelector, string date)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until<bool>(
                d => driver.FindElement(By.CssSelector(cssSelector)).Displayed);
            (driver as IJavaScriptExecutor).ExecuteScript(
                String.Format("$('{0}').datepicker('setDate', '{1}')", cssSelector, date));
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghjjklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

       
    }
}
