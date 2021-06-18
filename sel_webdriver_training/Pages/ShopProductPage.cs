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
    public class ShopProductPage : Page
    {
        public ShopProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void AddToCart(int n)
        {
            int i = 0;
            while (i < n)
            {
                driver.Url = "https://litecart.stqa.ru/ru/";
                driver.FindElement(By.ClassName("product")).Click();

                if (AreElementsPresent(By.Name("options[[untitled]]"))) { }
                else
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    string oldQtyString = driver.FindElement(By.CssSelector("#cart .content .quantity")).Text;
                    int oldQtyInt = Int16.Parse(oldQtyString);
                    int newQtyInt = oldQtyInt + 1;
                    driver.FindElement(By.Name("add_cart_product")).Click();
                    IWebElement newQty = driver.FindElement(By.CssSelector("#cart .content .quantity"));
                    wait.Until(ExpectedConditions.TextToBePresentInElement(newQty, newQtyInt.ToString()));
                    i++;
                };
            }
        }

        public bool IsElementPresent(By by)
        {
            driver.FindElement(by);
            return true;
        }

        public bool AreElementsPresent(By by) //эта функция ждет указанное в implicit wait время пока не найдет хоть один элемент
        {
            return driver.FindElements(by).Count > 0;
        }
        public void OpenCartCheckout()
        {
            driver.FindElement(By.CssSelector("#cart .link")).Click();
        }

    }
}

