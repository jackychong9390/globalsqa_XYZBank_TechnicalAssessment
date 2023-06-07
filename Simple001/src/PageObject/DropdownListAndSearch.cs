using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace Simple001.src.PageObject
{
    public class DropdownListAndSearch
    {
        private IWebDriver driver;

        public DropdownListAndSearch(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "searchDropdownBox")]
        public IWebElement searchBoxDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        public IWebElement searchBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Go']")]
        public IWebElement searchButton { get; set; }

        [FindsBy(How = How.Id, Using = "nav-search-submit-button")]
        public IWebElement searchSubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "nav-hamburger-menu")]
        public IWebElement hamburgerIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='hmenu-canvas-background']/div")]
        public IWebElement hideSidebar { get; set; }

        public void Search(string keyword)
        {
            searchBox.Clear();
            searchBox.SendKeys(keyword);
            Console.Write("search value is entered");
            searchButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
    }
}
