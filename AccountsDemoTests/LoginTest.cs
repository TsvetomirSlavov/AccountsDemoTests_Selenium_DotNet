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
        [Test]
        public void UserCanLoginSuccessfully()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");

            IWebDriver driver = driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            driver.FindElement(By.Id("user_email")).SendKeys("account1@ad.com");
            driver.FindElement(By.Id("user_password")).SendKeys("password");
            driver.FindElement(By.Name("commit")).Click();

            Assert.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match");
            
            driver.Quit();
        }

        [Test]
        public void UserShouldBeForcedToLoginWhenAccessesAuthenticatedPages()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");

            IWebDriver driver = driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/clients");
            driver.FindElement(By.Id("user_email")).SendKeys("account1@ad.com");
            driver.FindElement(By.Id("user_password")).SendKeys("password");
            driver.FindElement(By.Name("commit")).Click();
            
            Assert.AreEqual("http://accountsdemo.herokuapp.com/clients", driver.Url.ToString(),
                "User should have been landed in Clients Page");
            
            driver.Quit();
        }
    }
}
