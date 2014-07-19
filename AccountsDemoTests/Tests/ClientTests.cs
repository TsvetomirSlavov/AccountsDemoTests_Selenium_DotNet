using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AccountsDemoTests.Tests
{
    [TestFixture]
    public class ClientTests : TestBase
    {
        [Test]
        public void UserCanCreateClientOnlyWithMandatoryFieldsSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            SignInPage.SignIn("account1@ad.com", "password");

            String uniqueTime = DateTime.Now.ToString("ddMMyyhhmmssffff");
            String companyName = String.Format("DemoCompany {0}", uniqueTime);
            String contactPersonName = String.Format("Contact Person {0}", uniqueTime);

            AddNewClientPage.AddNewClient(companyName, contactPersonName);

            Assert.AreEqual(string.Format("DemoCompany {0}", uniqueTime), 
                                driver.FindElement(By.CssSelector("div.header>h1")).Text,
                    "Company name did not match");
        }

        [Test]
        public void UserCanCreateClientWithAddressSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            SignInPage.SignIn("account1@ad.com", "password");

            String uniqueTime = DateTime.Now.ToString("ddMMyyhhmmssffff");
            String companyName = String.Format("DemoCompany {0}", uniqueTime);
            String contactPersonName = String.Format("Contact Person {0}", uniqueTime);
            String address = String.Format("Client Full Address {0}", uniqueTime);

            AddNewClientPage.AddNewClient(companyName, contactPersonName, address);
            Assert.AreEqual(string.Format("DemoCompany {0}", uniqueTime),
                                driver.FindElement(By.CssSelector("div.header>h1")).Text,
                    "Company name did not match");
        }
    }
}
