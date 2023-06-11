using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Simple001.src.PageObject;
using System;
using System.Threading;

namespace Simple001.Tests
{
    [TestFixture, Order(1)]
    public class XYZBankHomePageTest
    {
        private IWebDriver driver;
        private XYZBankHomePage homePage;
        private BankManager_AddNewCustomer addCustomer;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
            homePage = new XYZBankHomePage(driver);
            addCustomer = new BankManager_AddNewCustomer(driver);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
        [Test]
        public void VerifyPageTitle()
        {
            string pageTitle = driver.Title;
            Assert.AreEqual("XYZ Bank", pageTitle);
            Console.WriteLine("Search test ran successfully.");
        }


    }
}
