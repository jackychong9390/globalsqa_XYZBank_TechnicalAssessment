using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple001.src.PageObject
{
    public class XYZBankHomePage
    {
        private IWebDriver driver;

        public XYZBankHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //From Homepage

        [FindsBy(How = How.XPath, Using = "//button[normalize-space(text())='Bank Manager Login']")]
        public IWebElement BankManagerLoginButton { get; set; }

    }
}
