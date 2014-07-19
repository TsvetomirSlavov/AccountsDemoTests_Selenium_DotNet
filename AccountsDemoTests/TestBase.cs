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

    }
}
