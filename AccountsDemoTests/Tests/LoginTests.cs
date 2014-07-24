using AccountsDemoTests.Common;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AccountsDemoTests.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void UserCanLoginSuccessfully()
        {
            driver.Navigate().GoToUrl(Constants.APPLICATION_URL);
            SignInPage.SignIn("account1@ad.com", "password");

            Verify.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match");
        }

        [Test]
        public void UserShouldBeForcedToLoginWhenAccessesAuthenticatedPages()
        {
            driver.Navigate().GoToUrl(string.Format("{0}/clients", Constants.APPLICATION_URL));
            SignInPage.SignIn("account1@ad.com", "password");
            
            Verify.AreEqual(string.Format("{0}/clients", Constants.APPLICATION_URL), driver.Url.ToString(),
                "User should have been landed in Clients Page");
        }
    }
}
