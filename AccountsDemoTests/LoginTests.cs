using NUnit.Framework;
using OpenQA.Selenium;

namespace AccountsDemoTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void UserCanLoginSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            SignInPage.SignIn("account1@ad.com", "password");

            Assert.True(driver.FindElement(By.CssSelector(".header>div>h2")).Text.StartsWith("Harry"),
                "Signed in User name did not match");
        }

        [Test]
        public void UserShouldBeForcedToLoginWhenAccessesAuthenticatedPages()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/clients");
            SignInPage.SignIn("account1@ad.com", "password");
            
            Assert.AreEqual("http://accountsdemo.herokuapp.com/clients", driver.Url.ToString(),
                "User should have been landed in Clients Page");
        }
    }
}
