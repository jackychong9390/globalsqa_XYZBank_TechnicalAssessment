using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Simple001.src.PageObject;
using System.Threading;

namespace Simple001.Tests
{
    [TestFixture, Order(1)]
    public class BankManager_AddCustomerTest
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
        public void AddCustomerTest()
        {
            homePage.BankManagerLoginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            addCustomer.AddCustomersButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Console.WriteLine("Add Customer Button Click succesfully");
            addCustomer.AddNewCustomers();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            customerTable.CustomersButton.Click();
            Console.WriteLine("Customer Button Click succesfully");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // customerTable.VerifyCustomersAvailability();

            customerTable.DeleteCustomers();
            Thread.Sleep(TimeSpan.FromSeconds(2));

           
  

        }


        // A method to read excel data
        public static void PrintSpreadSheetData(string workbookName)
        {
            string[][] data = DataReader.GetSpreadSheetData(workbookName);

            if (data != null)
            {
                for (int row = 0; row < data.Length; row++)
                {
                    for (int column = 0; column < data[row].Length; column++)
                    {
                        Console.Write(data[row][column] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
  
       

    }
}
