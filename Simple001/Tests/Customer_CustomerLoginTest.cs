using Microsoft.Graph.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Simple001.src.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple001.Tests
{
    [TestFixture, Order(2)]
    public class Customer_CustomerLoginTest
    {
        private IWebDriver driver;
        private XYZBankHomePage homePage;
        private Customer_CustomerLogin customerLogin;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
            homePage = new XYZBankHomePage(driver);
            customerLogin = new Customer_CustomerLogin(driver);
            driver.Manage().Window.Maximize();
            Console.Write("Entering the page \n");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void VerifyCustomerLogin()
        {
            homePage.CustomerLoginButton.Click();
            Console.WriteLine("Customer Login button clicked succesfully");
            customerLogin.SelectCustomerToLogin();
            Console.WriteLine("Customer Hermoine Granger Login succesfully");
            customerLogin.SelectCustomerPageDropdown();
            Console.WriteLine("1003 from dropdown selected");
             customerLogin.PerformTransactions();

    

   

 



        }





    }
}
