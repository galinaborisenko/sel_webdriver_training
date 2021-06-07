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
    public class Task7 : TestBase
    {
        [Test]
        public void Test1()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Id("box-login")).FindElement(By.Name("login")).Click();
 
            IList<IWebElement> menuItems = driver.FindElements(By.CssSelector("#box-apps-menu>li"));
            int numberOfMenuItems = menuItems.Count();      
            
            for (int i = 0; i < numberOfMenuItems; i++)
            {
                menuItems = driver.FindElements(By.CssSelector("#box-apps-menu>li"));
                menuItems[i].Click();
                //string menuTitle = driver.FindElement(By.TagName("h1")).Text;
                //Console.WriteLine(i + " " + menuTitle);
                Assert.IsTrue(AreElementsPresent(By.TagName("h1")));

                IList<IWebElement> subMenuItems = driver.FindElements(By.CssSelector("#box-apps-menu>li li"));
                int numberOfSubMenuIems = subMenuItems.Count;
                if (numberOfSubMenuIems > 0)
                {
                    for (int j = 0; j < numberOfSubMenuIems; j++)
                    {
                        subMenuItems = driver.FindElements(By.CssSelector("#box-apps-menu>li li"));
                        subMenuItems[j].Click();
                        //string subMenuTitle = driver.FindElement(By.TagName("h1")).Text;
                        //Console.WriteLine(i + "." + j + " " +subMenuTitle);
                        Assert.IsTrue(AreElementsPresent(By.TagName("h1")));
                    }
                }
            }
        }
    }
}
