using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AccountsDemoTests
{
    [TestFixture]
    public class LoginTest
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
        public void UserCanLoginSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            driver.FindElement(By.Id("user_email")).SendKeys("account1@ad.com");
            driver.FindElement(By.Id("user_password")).SendKeys("password");
            driver.FindElement(By.Name("commit")).Click();

            Assert.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match");
        }

        [Test]
        public void UserShouldBeForcedToLoginWhenAccessesAuthenticatedPages()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/clients");
            driver.FindElement(By.Id("user_email")).SendKeys("account1@ad.com");
            driver.FindElement(By.Id("user_password")).SendKeys("password");
            driver.FindElement(By.Name("commit")).Click();
            
            Assert.AreEqual("http://accountsdemo.herokuapp.com/clients", driver.Url.ToString(),
                "User should have been landed in Clients Page");
        }
    }
}
