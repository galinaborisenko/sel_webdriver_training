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

            List<string> unsortedCountryNames = new List<string>();          
            ICollection<IWebElement> countryItems = driver.FindElements(By.ClassName("row"));
            int numberOfCountries = countryItems.Count();
            for (int i = 0; i < numberOfCountries; i++)
            {
                foreach (IWebElement countryItem in countryItems)
                {
                    countryItems = driver.FindElements(By.ClassName("row"));
                    IList<IWebElement> countryCells = countryItem.FindElements(By.TagName("td"));
                    string countryName = countryCells[4].GetAttribute("textContent");
                    string zones = countryCells[5].GetAttribute("textContent");
                    if (zones != "0")
                    {
                        countryCells[6].Click();
                        List<string> unsortedZoneNames = new List<string>();
                        ICollection<IWebElement> zoneItems = driver.FindElements(By.CssSelector("#table-zones tr:not(.header)"));
                        foreach (IWebElement zoneItem in zoneItems)
                        {
                            zoneItems = driver.FindElements(By.CssSelector("#table-zones tr:not(.header)"));
                            IList<IWebElement> zoneCells = zoneItem.FindElements(By.TagName("td"));
                            if (zoneCells.Count > 1)
                            {
                                string zoneName = zoneCells[2].GetAttribute("textContent");
                                unsortedZoneNames.Add(zoneName);
                                Console.WriteLine(string.Join(" ", unsortedZoneNames));
                            }
                            List<string> sortedZoneNames = new List<string>();
                            sortedZoneNames.Sort();
                            Assert.AreEqual(unsortedZoneNames, sortedZoneNames);
                        }
                        navigationHelper.GoToAdminCountriesPage();
                    }
                    unsortedCountryNames.Add(countryName);
                    Console.WriteLine(string.Join(" ", unsortedCountryNames));
                    List<string> sortedCountryNames = new List<string>();
                    sortedCountryNames.Sort();
                 //   Assert.AreEqual(unsortedCountryNames, sortedCountryNames);
                } 

            }
        }
    }
}


