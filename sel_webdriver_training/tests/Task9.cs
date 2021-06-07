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
        public void AlphabeticalCountriesSort()
        {
            navigationHelper.GoToAdminHomePage();
            loginHelper.LoginAdmin();
            navigationHelper.GoToAdminCountriesPage();
            List<CountryData> unsortedCountriesList = countryZoneHelper.GetCountryList();
            List<CountryData> sortedCountriesList = countryZoneHelper.GetCountryList();
            sortedCountriesList.Sort();
            Console.WriteLine(string.Join(" ", unsortedCountriesList));
            Assert.AreEqual(unsortedCountriesList, sortedCountriesList);
        }

        [Test]
        public void GetCountryZoneList()
        {
            navigationHelper.GoToAdminHomePage();
            loginHelper.LoginAdmin();
            navigationHelper.GoToAdminCountriesPage();

            List<CountryData> unsortedCountryData = new List<CountryData>();
            List<ZoneData> unsortedZoneData = new List<ZoneData>();
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
                        int numberOfZones = zoneItems.Count();
                        for (int j = 0; j < numberOfZones - 1; j++)
                        {
                            foreach (IWebElement zoneItem in zoneItems)
                            {
                                IList<IWebElement> zoneCells = zoneItem.FindElements(By.TagName("td"));
                                string zoneName = zoneCells[3].GetAttribute("textContent");
                                unsortedZoneData.Add(new ZoneData(zoneName));
                                Console.WriteLine(string.Join(" ", unsortedZoneData));
                            }
                        }                       
                    }
                    unsortedCountryData.Add(new CountryData(countryName));
                    Console.WriteLine(string.Join(" ", unsortedCountryData));
                }
            }
        }
    }
}


