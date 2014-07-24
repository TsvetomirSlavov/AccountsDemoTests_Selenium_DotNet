using AccountsDemoTests.Common;
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
            driver.Navigate().GoToUrl(Constants.APPLICATION_URL);
            SignInPage.SignIn(Constants.USER_EMAIL, Constants.USER_PASSWORD);

            Verify.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match", true);
            driver.FindElement(By.CssSelector("span.glyphicon-log-out")).Click();
            
            Verify.True(driver.FindElement(By.Id("user_email")).Displayed, "Sould have landed in sign-in page");
        }
    }
}
