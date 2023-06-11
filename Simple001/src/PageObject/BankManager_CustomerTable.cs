using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Microsoft.Graph.Models;
using NPOI.SS.Formula.Functions;

namespace Simple001.src.PageObject
{
    public class BankManager_CustomerTable
    {
        private IWebDriver driver;

        public BankManager_CustomerTable(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // From Homepage - Bank Manager

        [FindsBy(How = How.CssSelector, Using = "button[ng-click='showCust()']")]
        public IWebElement CustomersButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[ng-click='addCust()']")]
        public IWebElement AddCustomersButton { get; set; }


        [FindsBy(How = How.XPath, Using = "(//button[normalize-space(text())='Add Customer'])[2]")]
        public IWebElement AddCustomers { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search Customer']")]
        private IWebElement customerSearchBox { get; set; }


        [FindsBy(How = How.XPath, Using = "(//button[normalize-space(text())='Delete'])[1]")]
        private IWebElement deleteCustomerButtonFirstRow { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[normalize-space(text())='Delete'])[2]")]
        private IWebElement deleteCustomerButtonSecondRow { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='table table-bordered table-striped']")]
        private IWebElement table { get; set; }

        public void searchAndDelete(string firstName, string lastName, string postCode)
        {
            customerSearchBox.Clear();
            customerSearchBox.SendKeys(postCode);
            Console.WriteLine("Keyword postCode entered: " + postCode + "\n");
            Console.WriteLine("Now begin\n");

            var rows = table.FindElements(By.TagName("tr"));

            for (int i = 1; i < rows.Count; i++)
            {
                rows = table.FindElements(By.TagName("tr")); // Re-locate the rows after each iteration

                var row = rows[i];
                var cells = row.FindElements(By.TagName("td"));

                if (cells.Count >= 3)
                {
                    var firstNameCell = cells[0].Text;
                    var lastNameCell = cells[1].Text;

                    if (firstNameCell.Equals(firstName, StringComparison.OrdinalIgnoreCase) && lastNameCell.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                    {
                        var deleteButton = row.FindElement(By.XPath(".//button[normalize-space(text())='Delete']"));
                        deleteButton.Click();
                        Console.WriteLine("Delete button is clicked\n");
                        Console.WriteLine(firstNameCell + " " + lastNameCell + " deleted\n");
                        break; // No need to continue looping after finding a match
                    }
                }
                else
                {
                    Console.WriteLine("No data available in the row.");
                }
            }

            customerSearchBox.Clear();
        }
        public void PrintTableData()
        {
            var rows = table.FindElements(By.TagName("tr"));

            for (int i = 1; i < rows.Count; i++)
            {
                var row = rows[i];
                var cells = row.FindElements(By.TagName("td"));

                if (cells.Count >= 3)
                {
                    var firstNameCell = cells[0].Text;
                    var lastNameCell = cells[1].Text;
                    var postCodeCell = cells[2].Text;

                    Console.WriteLine(i + "\n" + "First Name: " + firstNameCell + "\nLast Name: " + lastNameCell + "\nPostCode: " + postCodeCell + "\n");
                }
                else
                {
                    Console.WriteLine("No data available in the row.");
                }
            }
        }

        // Delete customers
        public void DeleteCustomers()
        {
            customerSearchBox.Clear();
            string[][] newDataSetVerify = null;

            newDataSetVerify = DataReader.GetSpreadSheetData("DeleteCustomers");

            int newTotalColumnsVerify = newDataSetVerify[0].Length;

            for (int r = 0; r < newDataSetVerify.Length; r++)
            {
                Console.WriteLine(newDataSetVerify[r][newTotalColumnsVerify - 3] + "  " + newDataSetVerify[r][newTotalColumnsVerify - 2] + "  " + newDataSetVerify[r][newTotalColumnsVerify - 1]);
                searchAndDelete(newDataSetVerify[r][newTotalColumnsVerify - 3], newDataSetVerify[r][newTotalColumnsVerify - 2], newDataSetVerify[r][newTotalColumnsVerify - 1]);
                customerSearchBox.Clear();
            }
            PrintTableData();
        }
    }
}
