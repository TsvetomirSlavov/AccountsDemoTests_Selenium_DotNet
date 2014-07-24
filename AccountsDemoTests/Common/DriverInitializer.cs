using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsDemoTests.Common
{
    class DriverInitializer
    {
        internal IWebDriver Initialize()
        {
            IWebDriver driver;
            
            if (Constants.BROWSER.Equals("chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("test-type");

                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                DriverProvider.Driver = driver;
                return driver;
            }
            // Handle for other browsers ...

            return null;
        }

    }
}
