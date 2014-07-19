using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AccountsDemoTests
{
    [TestFixture]
    public class LogoutTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void UserCanLogoutSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            driver.FindElement(By.Id("user_email")).SendKeys("account1@ad.com");
            driver.FindElement(By.Id("user_password")).SendKeys("password");
            driver.FindElement(By.Name("commit")).Click();

            Assert.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match");
            driver.FindElement(By.CssSelector("span.glyphicon-log-out")).Click();
            Assert.True(driver.FindElement(By.Id("user_email")).Displayed);
        }

    }
}
