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
        private BankManager_AddCustomer addCustomer;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
            addCustomer = new BankManager_AddCustomer(driver);
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
        public void VerifyPageTitle()
        {
            addCustomer.BankManagerLoginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string pageTitle = driver.Title;
            Assert.AreEqual("XYZ Bank", pageTitle);
            Console.WriteLine("Search test ran successfully.");
        }

        [Test]
        public void VerifyCustomerTable()
        {
            bankManager.BankManagerLoginButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("BankManagerLogin Button Click succesfully");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            bankManager.CustomersButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Console.WriteLine("Customer Button Click succesfully");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            PrintTableData();

        }
        [Test]
        public void VerifyAddCustomer()
        {
            bankManager.BankManagerLoginButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            bankManager.AddCustomersButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Console.WriteLine("Add Customer Button Click succesfully");

            bankManager.EnterCustomerDetails("John", "Doe", "12345");
            bankManager.ClickAddCustomerButton();
            // string successMessage = bankManager.GetSuccessMessage();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            AcceptCustomerAddedMessagePopUp();

        }

        [Test]
        public void ReadExcelFile()
        {
            PrintSpreadSheetData("CustomerRegistration");
        }

        public void PrintTableData()
        {

            // Wait for the table to load
            var table = driver.FindElement(By.XPath("//table[@class='table table-bordered table-striped']"));

            // Get all rows in the table
            var rows = table.FindElements(By.TagName("tr"));

            // Print out the data from each row
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                foreach (var cell in cells)
                {
                    Console.Write(cell.Text + "\t");
                }
                Console.WriteLine();
            }
        }

        //Accept customer adding verify pop-up
        public void AcceptCustomerAddedMessagePopUp()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

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
