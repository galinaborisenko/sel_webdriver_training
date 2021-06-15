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
    public class CountryZoneHelper
    {
        private IWebDriver driver;
        public CountryZoneHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public List<CountryData> GetCountryList()
        {
            List<CountryData> countryData = new List<CountryData>();
            ICollection<IWebElement> countryItems = driver.FindElements(By.ClassName("row"));
            foreach (IWebElement countryItem in countryItems)
            {
                IList<IWebElement> cells = countryItem.FindElements(By.TagName("td"));
                string name = cells[4].GetAttribute("href");
                countryData.Add(new CountryData(name));
                Console.WriteLine(name);
            }
            return new List<CountryData>(countryData);
        }

        public void GetCountryZoneList()
        {
            List<CountryData> countryData = new List<CountryData>();
            List<ZoneData> zoneData = new List<ZoneData>();
            ICollection<IWebElement> countryItems = driver.FindElements(By.ClassName("row"));
            int numberOfCountries = countryItems.Count();
            for (int i = 0; i < numberOfCountries; i++)
            {
                foreach (IWebElement countryItem in countryItems)
                {
                    IList<IWebElement> countryCells = countryItem.FindElements(By.TagName("td"));
                    string countryName = countryCells[4].GetAttribute("textContent");
                    string zones = countryCells[5].GetAttribute("textContent");
                    if (zones != "0")
                    {

                        countryCells[6].Click();
                        ICollection<IWebElement> zoneItems = driver.FindElements(By.CssSelector("#table-zones tr:not(.header)"));
                        foreach (IWebElement zoneItem in zoneItems)
                        {
                            IList<IWebElement> zoneCells = zoneItem.FindElements(By.TagName("td"));
                            string zoneName = zoneCells[3].GetAttribute("textContent");
                            zoneData.Add(new ZoneData(zoneName));
                            Console.WriteLine(zoneName);
                        }
                    }
                    countryData.Add(new CountryData(countryName));
                    Console.WriteLine(countryName);
                }
            }
        }
    }
}
