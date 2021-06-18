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

namespace litecart
{
    public class NavigationHelper
    {
        private IWebDriver driver;
        public NavigationHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToAdminHomePage() 
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
        }
        public void GoToShopHomePage()
        {
            driver.Url = "https://litecart.stqa.ru/ru/";
        }

        public void GoToAdminCountriesPage()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
        }

        public void GoToAdminCatalogPage()
        {
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
        }
        public void GoToAdminZonesPage()
        {
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
        }

    }
}
