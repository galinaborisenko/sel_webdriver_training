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
    public class Task9 : TestBase
    {  
        [Test]
        public void GetCountriesZonesLists()
        {
            navigationHelper.GoToAdminHomePage();
            loginHelper.LoginAdmin();
            navigationHelper.GoToAdminCountriesPage();

            List<string> countryNames = new List<string>();
            ICollection<IWebElement> countryItems = driver.FindElements(By.ClassName("row"));
            //Console.WriteLine(countryItems.Count());

            List<string> hrefs = new List<string>();

            foreach (IWebElement countryItem in countryItems)
            {
                IList<IWebElement> countryCells = countryItem.FindElements(By.TagName("td"));
                string countryName = countryCells[4].GetAttribute("textContent");
                string zones = countryCells[5].GetAttribute("textContent");

                if (zones != "0")
                {
                    string href = countryCells[6].FindElement(By.TagName("a")).GetAttribute("href");
                    hrefs.Add(href);
                }
                countryNames.Add(countryName);
            }
            //Console.WriteLine(string.Join(" ", countryNames));
            //Console.WriteLine(string.Join(" ", hrefs));
            List<string> sortedCountryNames = new List<string>(countryNames);
            sortedCountryNames.Sort();
            Assert.AreEqual(countryNames, sortedCountryNames);
            int n =  hrefs.Count();
            for (int i = 0; i < n; i++)
            {
                IWebElement link = driver.FindElement(By.CssSelector($"a[href*='{hrefs[i]}']"));
                link.Click();
                List<string> zoneNames = new List<string>();
                ICollection<IWebElement> zoneItems = driver.FindElements(By.CssSelector("#table-zones tr:not(.header):not(:last-child)"));
                foreach (IWebElement zoneItem in zoneItems)
                {
                    zoneItems = driver.FindElements(By.CssSelector("#table-zones tr:not(.header):not(:last-child)"));
                    IList<IWebElement> zoneCells = zoneItem.FindElements(By.TagName("td"));
                    string zoneName = zoneCells[2].GetAttribute("textContent");
                    zoneNames.Add(zoneName);
                    List<string> sortedZoneNames = new List<string>(zoneNames);
                    sortedZoneNames.Sort();
                    Assert.AreEqual(zoneNames, sortedZoneNames);
                }
                //Console.WriteLine(string.Join(" ", zoneNames));
                navigationHelper.GoToAdminCountriesPage();
            }
         }    
    }
}


