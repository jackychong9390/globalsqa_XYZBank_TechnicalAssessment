using System;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium.Interactions;

namespace Simple001.Tests
{

    class AddtoCart
    {
        IWebDriver driver = new ChromeDriver();

    [SetUp]
    public void Initialize()
    {
        driver.Navigate().GoToUrl("https://www.amazon.com/");
        driver.Manage().Cookies.DeleteAllCookies();
        driver.Manage().Window.Maximize();
        Console.Write("Entering the Amazon page \n");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

    }

        [Test, Order(1)]

        public void SelectFromSideMenu()
        {
            IWebElement ele = driver.FindElement(By.Id("twotabsearchtextbox"));
            ele.Click();

            ele.SendKeys("laptop");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Console.Write("search value is entered \n");
           
            Thread.Sleep(3000);
           
            // press Search button
            IWebElement ele2 = driver.FindElement(By.Id("nav-search-submit-button"));
            ele2.Click();
            Console.Write("Search button is clicked \n");

            Thread.Sleep(3000);

            //Clicked the first item
            IWebElement ele3 = driver.FindElement(By.ClassName("a-link-normal"));
            ele3.Click();
            Console.Write("First Item is clicked \n");

            Thread.Sleep(3000);

            IWebElement ele4 = driver.FindElement(By.ClassName("add-to-cart-button"));
            ele4.Click();
            Console.Write("Add to cart is clicked \n");

        }

        [TearDown]
    public void EndTest()
    {
        Console.Write("Exiting the Amazon page");
        //close the browser  
        driver.Close();
    }
}
}

