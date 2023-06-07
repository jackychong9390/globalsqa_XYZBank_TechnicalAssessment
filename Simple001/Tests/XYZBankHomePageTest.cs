using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Simple001.src.PageObject;
using System;

namespace Simple001.Tests
{
    [TestFixture, Order(1)]
    public class XYZBankHomePageTest
    {
        private IWebDriver driver;
        private BankManager_AddCustomer homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");
            homePage = new BankManager(driver);
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
