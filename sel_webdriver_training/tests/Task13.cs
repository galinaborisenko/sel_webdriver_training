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
    public class Task13 : TestBase
    {
        [Test]
        public void AddAndRemoveFromCartDucks()
        {
            int i = 0;
            while (i < 3)
            {             
                //1) открыть главную страницу
                //2) открыть первый товар из списка
                //2) добавить его в корзину(при этом может случайно добавиться товар, который там уже есть, ничего страшного)
                //3) подождать, пока счётчик товаров в корзине обновится
                navigationHelper.GoToShopHomePage();
                driver.FindElement(By.ClassName("product")).Click();

                if (AreElementsPresent(By.Name("options[[untitled]]"))){}
                else 
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    string  oldQtyString = driver.FindElement(By.CssSelector("#cart .content .quantity")).Text;
                    int oldQtyInt = Int16.Parse(oldQtyString);
                    int newQtyInt = oldQtyInt + 1;
                    driver.FindElement(By.Name("add_cart_product")).Click();
                    IWebElement newQty = driver.FindElement(By.CssSelector("#cart .content .quantity"));
                    wait.Until(ExpectedConditions.TextToBePresentInElement(newQty, newQtyInt.ToString()));
                    i++;
                };               
            }

            //5) открыть корзину (в правом верхнем углу кликнуть по ссылке Checkout)
            //6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица
            driver.FindElement(By.CssSelector("#cart .link")).Click();           
            driver.FindElement(By.CssSelector(".shortcuts li")).Click();
            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".shortcuts li"));
            int numberOfElements = elements.Count();
            IWebElement table = driver.FindElement(By.CssSelector(".dataTable tr>td"));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            while (numberOfElements > 0)
            {
                driver.FindElement(By.Name("remove_cart_item")).Click(); ;
                numberOfElements--;
                wait1.Until(ExpectedConditions.StalenessOf(table));
            }
        }

    }

}
