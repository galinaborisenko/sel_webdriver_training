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
    public class Task8 : TestBase
    {
        [Test]
        public void Test1() 
        {
            driver.Url = "https://litecart.stqa.ru/ru/";
            IList<IWebElement> productsList = driver.FindElements(By.ClassName("product"));
            foreach (IWebElement product in productsList)
            {
                IList<IWebElement> stickersForProduct = product.FindElements(By.ClassName("sticker"));
                int numberOfStickersForProduct = stickersForProduct.Count;
                Console.WriteLine(product.FindElement(By.ClassName("sticker")).Text + numberOfStickersForProduct);
                Assert.AreEqual(1,numberOfStickersForProduct);
            }
        }       
    }
}
