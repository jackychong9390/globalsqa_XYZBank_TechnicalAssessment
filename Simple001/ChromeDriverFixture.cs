using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Simple001
{
    public sealed class ChromeDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public ChromeDriverFixture()
        {
            Driver = new ChromeDriver();
        }

        public void Dispose()
        {
            Driver.Dispose();
        }


    }
}
