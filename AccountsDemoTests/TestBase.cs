using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AccountsDemoTests.Common;
using AccountsDemoTests.Pages;

namespace AccountsDemoTests
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver driver;

        public SignInPage SignInPage;

        [SetUp]
        protected void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            DriverProvider.Driver = driver;

            SignInPage = SignInPage ?? SignInPage.Instance;
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        protected void AddNewClient(String companyName, String contactPersonName, String address = "")
        {
            IWebElement clientsLink = driver.FindElement(By.CssSelector("nav.navbar"))
                                        .FindElement(By.LinkText("CLIENTS"));
            clientsLink.Click();

            driver.FindElement(By.LinkText("+ Add New Client")).Click();

            driver.FindElement(By.Id("client_company_name")).SendKeys(companyName);
            driver.FindElement(By.Id("client_contact_person_name")).SendKeys(contactPersonName);

            if (address != "")
                driver.FindElement(By.Id("client_address")).SendKeys(address);

            driver.FindElement(By.Name("commit")).Click();

        }


    }
}
