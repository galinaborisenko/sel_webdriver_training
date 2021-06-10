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
using System.Threading;

namespace litecart
{
    public class Task12 : TestBase
    {
        [Test]
        public void AddNewProductInCatalogAdmin()
        {
            navigationHelper.GoToAdminHomePage();
            loginHelper.LoginAdmin();
            navigationHelper.GoToAdminCatalogPage();
            driver.FindElement(By.CssSelector("a[href*=\"edit_product\"]")).Click();
            //Fill in General
            //Status
            IWebElement statusEnabled = 
                driver.FindElement(By.CssSelector("input[name=\"status\"][value=\"1\"]"));
            if (statusEnabled.GetAttribute("checked") == null )
            {
                statusEnabled.Click();
            }
            //Name
            string name = "tapok";
            Type(By.CssSelector("input[name*=\"name\"]"), name);

            //Code
            Type(By.Name("code"), "1100TP");

            //Category
            driver.FindElement(By.CssSelector("input[name*=\"categories\"][value=\"1\"]")).Click();

            //Default Category
            SelectElement drpDefCat = new SelectElement(driver.FindElement(By.Name("default_category_id")));
            drpDefCat.SelectByValue("1");

            // Product Group
            driver.FindElement(By.CssSelector("input[name*=\"product_groups\"][value=\"1-2\"]")).Click();

            //Qty
            Type(By.Name("quantity"), "100");

            //Image
            Type(By.Name("new_images[]"), "C:\\Users\\hborysenko\\Downloads\\tapok.jpg");


            //Set dates (today =  DateTime.Now.ToString("M/d/yyyy"))
            Type(By.Name("date_valid_from"), "2021-08-08");
            Type(By.Name("date_valid_to"), "2025-08-08");

            //Information
            driver.FindElement(By.CssSelector("a[href*=\"information\"]")).Click();
            SelectElement drpManufId = new SelectElement(driver.FindElement(By.Name("manufacturer_id")));
            drpManufId.SelectByValue("1");
            Type(By.Name("keywords"), "tapok, lapti");
            Type(By.Name("short_description[en]"), "tapok");
            Type(By.ClassName("trumbowyg-editor"), "Very nice tapok!");
            // IWebElement longDescr =  driver.FindElement(By.Name("description[en]"));
            // IJavaScriptExecutor jseLongDescr = (IJavaScriptExecutor)driver;
            //  jseLongDescr.ExecuteScript("arguments[0].setAttribute('value',arguments[1]);",longDescr, "Very nice tapok!");
            Type(By.Name("head_title[en]"), "head tapok");
            Type(By.Name("meta_description[en]"), "meta tapok");

            //Price
            driver.FindElement(By.CssSelector("a[href*=\"prices\"]")).Click();
            Type(By.Name("purchase_price"), "50.50");
            IWebElement drpCurrency = driver.FindElement(By.Name("purchase_price_currency_code"));
            IJavaScriptExecutor jseDrpCurrency = (IJavaScriptExecutor)driver;
            jseDrpCurrency.ExecuteScript("arguments[0].selectedIndex = 1; arguments[0].dispatchEvent(new Event('change'))", drpCurrency);
            Type(By.Name("prices[USD]"), "60.50");
            Type(By.Name("prices[EUR]"), "40.50");

            //Thread.Sleep(1000);
            IWebElement saveButton = driver.FindElement(By.Name("save"));
            IJavaScriptExecutor jseSaveButton = (IJavaScriptExecutor)driver;
            jseSaveButton.ExecuteScript("arguments[0].click();", saveButton);

            //Thread.Sleep(1000);
            Assert.IsTrue(IsElementPresent(By.CssSelector(".notice.success")));
            string productName = driver.FindElement(By.CssSelector(".dataTable tr td a[href*=product]")).Text;
            Assert.AreEqual(name, productName);
        }
    }
}
