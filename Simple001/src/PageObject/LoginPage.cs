using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple001.src.PageObject
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement EmailInput => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement SubmitButton => _driver.FindElement(By.Id("submit"));


        public void Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
        }

    }
}
