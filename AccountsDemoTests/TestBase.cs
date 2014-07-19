using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AccountsDemoTests
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        protected void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        protected void Login(String userName, String password)
        {
            driver.FindElement(By.Id("user_email")).SendKeys(userName);
            driver.FindElement(By.Id("user_password")).SendKeys(password);
            driver.FindElement(By.Name("commit")).Click();
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
