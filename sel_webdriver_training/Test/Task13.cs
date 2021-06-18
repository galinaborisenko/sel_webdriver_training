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
            app.shopMainPage.Open();
            app.shopProductPage.AddToCart(3);
            app.shopProductPage.OpenCartCheckout();
            app.shopCartPage.ClickOnFirstProductInCarousel();
            app.shopCartPage.RemoveAllProductsFromCart();
        }

    }

}
