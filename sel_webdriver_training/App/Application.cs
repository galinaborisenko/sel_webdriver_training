using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace litecart
{
    public class Application
    {
        private IWebDriver driver;

        public ShopMainPage shopMainPage;
        public ShopProductPage shopProductPage;
        public ShopCartPage shopCartPage;

        public Application()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            shopMainPage = new ShopMainPage(driver);
            shopProductPage = new ShopProductPage(driver);
            shopCartPage = new ShopCartPage(driver);
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
