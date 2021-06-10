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
        public void Test()
        {
            //1) открыть главную страницу
            navigationHelper.GoToShopHomePage();
            //2) открыть первый товар из списка
            driver.FindElement(By.ClassName("product")).Click();
            //2) добавить его в корзину(при этом может случайно добавиться товар, который там уже есть, ничего страшного)
            driver.FindElement(By.Name("add_cart_product")).Click();
            //3) подождать, пока счётчик товаров в корзине обновится

            //4) вернуться на главную страницу, повторить предыдущие шаги ещё два раза, чтобы в общей сложности в корзине было 3 единицы товара
            navigationHelper.GoToShopHomePage();
            driver.FindElement(By.ClassName("product")).Click();
            driver.FindElement(By.Name("add_cart_product")).Click();
            //подождать, пока счётчик товаров в корзине обновится

            navigationHelper.GoToShopHomePage();
            driver.FindElement(By.ClassName("product")).Click();
            driver.FindElement(By.Name("add_cart_product")).Click();
            //подождать, пока счётчик товаров в корзине обновится

            //5) открыть корзину (в правом верхнем углу кликнуть по ссылке Checkout)
            driver.Url = "https://litecart.stqa.ru/ru/checkout";
            //driver.FindElement(By.CssSelector("[href*=\"checkout\"]")).Click();
            //6) удалить все товары из корзины один за другим, после каждого удаления подождать, пока внизу обновится таблица
            driver.FindElement(By.CssSelector(".shortcuts li")).Click();
            IList<IWebElement> elements = driver.FindElements(By.CssSelector(".shortcuts li"));
            int numberOfElements = elements.Count();
            //IWebElement table = driver.FindElement(By.Id("box-checkout-summary"));
            while (numberOfElements > 0)
            {
                int i = 1;
                i++;
                elements = driver.FindElements(By.Name("remove_cart_item"));
                elements[i].Click();
            }
            ///for (int i = 0; i < numberOfElements; i++)
           // {
              //  elements = driver.FindElements(By.Name("remove_cart_item"));
             //   elements[i].Click();
              //  WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              // driver.Navigate().Refresh();
              //  wait.Until(ExpectedConditions.StalenessOf(table));
           // }
        }

    }

}
