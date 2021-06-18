using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litecart
{
    public class ShopMainPage : Page
    {
        public ShopMainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void Open()
        {
            driver.Url = "https://litecart.stqa.ru/ru/";
        }
    }
}
