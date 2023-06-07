using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Simple001.src.PageObject;


namespace Simple001.Tests
{
    [TestFixture, Order(1)]
    public class DropdownListAndSearchTest
    {
        private IWebDriver driver;
        private DropdownListAndSearch dropdownListAndSearch;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
            dropdownListAndSearch = new DropdownListAndSearch(driver);
            driver.Manage().Window.Maximize();
            Console.Write("Entering the Amazon page");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }

        [Test]
        public void SelectFromDropdown()
        {

            string pageTitle = driver.Title;
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", pageTitle);

            List<string> elementTexts = new List<string>(driver.FindElements(By.ClassName("nav-search-dropdown")).Select(iw => iw.Text));

            if (elementTexts != null)
            {
                foreach (var element in elementTexts)
                {
                    Console.WriteLine(String.Join("\n", element));
                }
                Console.Write("Now Checking some values from the dropdown \n");
            }

            // IWebElement ele1 = driver.FindElement(By.Id("searchDropdownBox"));
            //  dropdownListAndSearch.searchBoxDropdown.Click();

            var selectElement = new SelectElement(dropdownListAndSearch.searchBoxDropdown);
            selectElement.SelectByText("Books");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // verify some of the options of a drop down
            String[] drop = { "Books", "Baby", "Computers" };
            IEnumerable<String> actual = selectElement.Options.Select(i => i.Text);
            Assert.IsTrue(drop.All(d => actual.Contains(d)));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            dropdownListAndSearch.Search("laptop");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Console.Write("search value is entered \n");

            dropdownListAndSearch.searchSubmitButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Console.Write("search button is clicked \n");

            dropdownListAndSearch.hamburgerIcon.Click();
            Console.Write("hamburger icon is clicked /n");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            dropdownListAndSearch.hideSidebar.Click();
            Console.Write("Close the size menu  \n");

        }


        [TearDown]
        public void EndTest()
        {
            Console.Write("Exiting the Amazon page");
            //close the browser  
            driver.Quit();
        }

    }
}
