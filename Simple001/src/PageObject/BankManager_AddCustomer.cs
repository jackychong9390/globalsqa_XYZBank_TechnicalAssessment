using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Simple001.src.PageObject
{
    public class BankManager_AddCustomer
    {
        private IWebDriver driver;

        //From Homepage

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Bank Manager Login']")]
        public IWebElement BankManagerLoginButton { get; set; }

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

        public void ClickAddCustomerButton()
        {
            // Assuming the second button is the one we want to click
            AddCustomers.Click();
        }

        public string GetSuccessMessage()
        {
            return successMessage.Text;
        }


        public BankManager_AddCustomer(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

    }
}
