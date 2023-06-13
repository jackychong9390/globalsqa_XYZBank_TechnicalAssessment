using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Simple001.src.PageObject
{
    public class BankManager_AddNewCustomer
    {
        private IWebDriver driver;

        public BankManager_AddNewCustomer(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //From Homepage - Bank Manager

        [FindsBy(How = How.CssSelector, Using = "button[ng-click='showCust()']")]
        public IWebElement CustomersButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[ng-click='addCust()']")]
        public IWebElement AddCustomersButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='First Name']")]
        public IWebElement AddCustomerFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Last Name']")]
        public IWebElement AddCustomerLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Post Code']")]
        public IWebElement AddCustomerPostCode { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[normalize-space(text())='Add Customer'])[2]")]
        public IWebElement AddCustomers { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='error ng-binding']")]
        private IWebElement successMessage;

        public void EnterCustomerDetails(string firstName, string lastName, string postCode)
        {
            this.AddCustomerFirstName.SendKeys(firstName);
            this.AddCustomerLastName.SendKeys(lastName);
            this.AddCustomerPostCode.SendKeys(postCode);
        }

        // Add new customers based from the Sheet Data
        public void AddNewCustomers()
        {
            try
            {
                string[][] newDataSet = null;

                newDataSet = DataReader.GetSpreadSheetData("CustomerRegistration");

                int newTotalColumns = newDataSet[0].Length;

                for (int r = 0; r < newDataSet.Length; r++)
                {
                    EnterCustomerDetails(newDataSet[r][newTotalColumns - 3], newDataSet[r][newTotalColumns - 2], newDataSet[r][newTotalColumns - 1]);
                    ClickAddCustomerButton();
                    AcceptCustomerAddedMessagePopUp();

                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void ClickAddCustomerButton()
        {
            // Assuming the second button is the one we want to click
            AddCustomers.Click();
        }

        public string GetSuccessMessage()
        {
            return successMessage.Text;
        }

        //Accept customer adding verify pop-up
        public void AcceptCustomerAddedMessagePopUp()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }



    }

}
