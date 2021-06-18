using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litecart
{
    public class ShopCartPage : Page
    {
        public ShopCartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public void ClickOnFirstProductInCarousel()
        {
            if (IsMoreThanOneProductInCart())
            {
                driver.FindElement(By.CssSelector(".shortcuts li")).Click();
            }          
        }

        public bool IsMoreThanOneProductInCart()
        {
            return AreElementsPresent(By.CssSelector(".shortcuts li"));
        }

        public void RemoveAllProductsFromCart()
        {
            if (IsMoreThanOneProductInCart())
            {
                IList<IWebElement> elements = driver.FindElements(By.CssSelector(".shortcuts li"));
                int numberOfElements = elements.Count();
                IWebElement table = driver.FindElement(By.CssSelector(".dataTable tr>td"));
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                while (numberOfElements > 0)
                {
                    driver.FindElement(By.Name("remove_cart_item")).Click(); 
                    numberOfElements--;
                    wait1.Until(ExpectedConditions.StalenessOf(table));
                }
            }
            else 
            {
                driver.FindElement(By.Name("remove_cart_item")).Click();
                IWebElement table = driver.FindElement(By.CssSelector(".dataTable tr>td"));
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait1.Until(ExpectedConditions.StalenessOf(table));
            }        
        }

        public bool AreElementsPresent(By by) //эта функция ждет указанное в implicit wait время пока не найдет хоть один элемент
        {
            return driver.FindElements(by).Count > 0;
        }
    }
}
