using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AccountsDemoTests.Common;
using AccountsDemoTests.Pages;

namespace AccountsDemoTests.Tests
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver driver;

        public SignInPage SignInPage;
        public AddNewClientPage AddNewClientPage;

        [SetUp]
        protected void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            DriverProvider.Driver = driver;

            SignInPage = SignInPage ?? SignInPage.Instance;
            AddNewClientPage = AddNewClientPage ?? AddNewClientPage.Instance;
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
    }
}
