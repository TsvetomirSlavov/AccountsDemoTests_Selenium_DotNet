using NUnit.Framework;
using OpenQA.Selenium;

namespace AccountsDemoTests.Tests
{
    [TestFixture]
    public class LogoutTests : TestBase
    {
        [Test]
        public void UserCanLogoutSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            SignInPage.SignIn("account1@ad.com", "password");

            Assert.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match");
            driver.FindElement(By.CssSelector("span.glyphicon-log-out")).Click();
            Assert.True(driver.FindElement(By.Id("user_email")).Displayed);
        }
    }
}
