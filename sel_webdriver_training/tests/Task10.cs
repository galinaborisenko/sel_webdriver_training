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
    public class Task10 : TestBase
    {
        [Test]
        public void TheSameHrefOnHomeAndProductPages()
        {
            navigationHelper.GoToShopHomePage();
            string hrefOnHomePage, hrefOnProductPage;
            IWebElement utka = driver.FindElement(By.CssSelector("#box-campaigns .product"));
            hrefOnHomePage = utka.GetAttribute("href");
            utka.Click();
            hrefOnProductPage = driver.FindElement(By.TagName("html")).GetAttribute("href");
            Assert.AreEqual(hrefOnHomePage, hrefOnProductPage);
        }

        [Test]
        public void TheSameTitleOnHomeAndProductPages()
        {
            navigationHelper.GoToShopHomePage();
            string titleOnHomePage, titleOnProductPage;
            titleOnHomePage = driver.FindElement(By.CssSelector("#box-campaigns .product .name")).Text;
            driver.FindElement(By.CssSelector("#box-campaigns .product .name")).Click();
            titleOnProductPage=driver.FindElement(By.CssSelector("#box-product .title")).Text;

            Assert.AreEqual(titleOnHomePage, titleOnProductPage);
        }

        [Test]
        public void TheSamePricesOnHomeAndProductPages()
        {
            navigationHelper.GoToShopHomePage();
            string regPriceValueOnHomePage, regPriceValueOnProductPage, salePriceValueOnHomePage, salePriceValueOnProductPage;

            IWebElement utka = driver.FindElement(By.CssSelector("#box-campaigns .product"));
            regPriceValueOnHomePage = utka.FindElement(By.ClassName("regular-price")).Text;
            salePriceValueOnHomePage = utka.FindElement(By.ClassName("campaign-price")).Text;

            utka.Click();
            regPriceValueOnProductPage = driver.FindElement(By.ClassName("regular-price")).Text;
            salePriceValueOnProductPage = driver.FindElement(By.ClassName("campaign-price")).Text;

            Assert.AreEqual(regPriceValueOnHomePage, regPriceValueOnProductPage);
            Assert.AreEqual(salePriceValueOnHomePage, salePriceValueOnProductPage);
        }

        [Test]
        public void SalePriceFontSizeBiggerOnHomePage()
        {
            navigationHelper.GoToShopHomePage();
            IWebElement utka = driver.FindElement(By.CssSelector("#box-campaigns .product"));
            char[] charsToTrim = { 'p', 'x' };
            string regPriceSizeInStringOnHomePage = utka.FindElement(By.ClassName("regular-price")).GetCssValue("font-size");
            double regPriceSizeOnHomePage = Convert.ToInt64(Convert.ToDouble(regPriceSizeInStringOnHomePage.Trim(charsToTrim),
                CultureInfo.InvariantCulture.NumberFormat));

            string salePriceSizeInStringOnHomePage = utka.FindElement(By.ClassName("campaign-price")).GetCssValue("font-size");
            double salePriceSizeOnHomePage = Convert.ToInt64(Convert.ToDouble(salePriceSizeInStringOnHomePage.Trim(charsToTrim),
                CultureInfo.InvariantCulture.NumberFormat));
            Assert.Greater(salePriceSizeOnHomePage, regPriceSizeOnHomePage);
        }

        [Test]
        public void SalePriceFontSizeBiggerOnProductPage()
        {
            navigationHelper.GoToShopHomePage();
            IWebElement utka = driver.FindElement(By.CssSelector("#box-campaigns .product"));
            utka.Click();
            char[] charsToTrim = { 'p', 'x' };
            string regPriceSizeInStringOnProductPage = driver.FindElement(By.ClassName("regular-price")).GetCssValue("font-size");
            double regPriceSizeOnProductPage = Convert.ToInt64(Convert.ToDouble(regPriceSizeInStringOnProductPage.Trim(charsToTrim),
                CultureInfo.InvariantCulture.NumberFormat));

            string salePriceSizeInStringOnProductPage = driver.FindElement(By.ClassName("campaign-price")).GetCssValue("font-size");
            double salePriceSizeOnProductPage = Convert.ToInt64(Convert.ToDouble(salePriceSizeInStringOnProductPage.Trim(charsToTrim),
                CultureInfo.InvariantCulture.NumberFormat));
            Assert.Greater(salePriceSizeOnProductPage, regPriceSizeOnProductPage);
        }

        [Test]
        public void SalePriceIsRedAndBoldOnHomePage()
        {
            navigationHelper.GoToShopHomePage();
            IWebElement utka = driver.FindElement(By.CssSelector("#box-campaigns .product"));
            string color = utka.FindElement(By.ClassName("campaign-price")).GetCssValue("color");
            string fontWeight = utka.FindElement(By.ClassName("campaign-price")).GetCssValue("font-weight");
            //Console.WriteLine(fontWeight);
            string[] value = color.Replace("rgb(", "").Replace(")", "").Split(',');
            value[0] = value[0].Trim();
            int valueR= Int16.Parse(value[0]);
            value[1] = value[1].Trim();
            int valueG = Int16.Parse(value[1]);
            value[2] = value[2].Trim();
            int valueB = Int16.Parse(value[2]);
            Assert.Greater(valueR, 0);
            Assert.AreEqual(0, valueG);
            Assert.AreEqual(0, valueB);
            Assert.AreEqual("900", fontWeight);
        }

        [Test]
        public void RegularPriceIsGreyAndCrossedOutOnHomePage()
        {
            navigationHelper.GoToShopHomePage();
            IWebElement utka = driver.FindElement(By.CssSelector("#box-campaigns .product"));
            string color = utka.FindElement(By.ClassName("regular-price")).GetCssValue("color");
            string crossedOut = utka.FindElement(By.ClassName("regular-price")).GetCssValue("text-decoration");
            Console.WriteLine(color);
            Console.WriteLine(crossedOut);
            string[] value = color.Replace("rgb(", "").Replace(")", "").Split(',');
            value[0] = value[0].Trim();
            int valueR = Int16.Parse(value[0]);
            value[1] = value[1].Trim();
            int valueG = Int16.Parse(value[1]);
            value[2] = value[2].Trim();
            int valueB = Int16.Parse(value[2]);
            Assert.AreEqual(119, valueR);
            Assert.AreEqual(119, valueG);
            Assert.AreEqual(119, valueB);
            Assert.IsTrue(crossedOut.Contains("line-through"));
        }
    }
}
