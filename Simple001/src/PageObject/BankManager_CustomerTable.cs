using OpenQA.Selenium;
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

       // public BankManager_CustomerTable(IWebDriver driver)
       // {
       //     this.driver = driver;
       //     PageFactory.InitElements(driver, this);
        // }

        //From Homepage

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Bank Manager Login']")]
        public IWebElement BankManagerLoginButton { get; set; }

        //From Homepage - Bank Manager

        [FindsBy(How = How.CssSelector, Using = "button[ng-click='showCust()']")]
        public IWebElement CustomersButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[ng-click='addCust()']")]
        public IWebElement AddCustomersButton { get; set; }



        [FindsBy(How = How.XPath, Using = "(//button[normalize-space(text())='Add Customer'])[2]")]
        public IWebElement AddCustomers { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='error ng-binding']")]
        private IWebElement successMessage;



     
    

    }
}
