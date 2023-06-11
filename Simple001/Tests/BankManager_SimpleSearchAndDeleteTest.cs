using NPOI.SS.Formula.Functions;
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
    public class BankManager_SimpleSearchAndDeleteTest
    {
        private IWebDriver driver;
        private BankManager_AddNewCustomer addCustomer;
        private BankManager_CustomerTable customerTable;
        private XYZBankHomePage homePage;

  

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
            addCustomer = new BankManager_AddNewCustomer(driver);
            homePage = new XYZBankHomePage(driver);
            customerTable = new BankManager_CustomerTable(driver);
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
        public void VerifyAddCustomer()
        {
            homePage.BankManagerLoginButton.Click();
            customerTable.CustomersButton.Click();
            Console.WriteLine("Customer Button Click succesfully");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // customerTable.VerifyCustomersAvailability();

            customerTable.DeleteCustomers();
            Console.WriteLine("searchAndDelete method called");
            Thread.Sleep(TimeSpan.FromSeconds(5));




        }



    }
}
