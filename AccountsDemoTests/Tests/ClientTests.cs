using System;
using NUnit.Framework;
using OpenQA.Selenium;
using AccountsDemoTests.Entities;
using AccountsDemoTests.Common;

namespace AccountsDemoTests.Tests
{
    [TestFixture]
    public class ClientTests : TestBase
    {
        [Test]
        public void UserCanCreateClientOnlyWithMandatoryFieldsSuccessfully()
        {
            String uniqueTime = DateTime.Now.ToString("ddMMyyhhmmssffff");
            String companyName = String.Format("DemoCompany {0}", uniqueTime);
            String contactPersonName = String.Format("Contact Person {0}", uniqueTime);
            Client client = new Client(companyName, contactPersonName);

            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            SignInPage.SignIn("account1@ad.com", "password");

            AddNewClientPage.AddNewClient(client);

            Verify.AreEqual(string.Format("DemoCompany {0}", uniqueTime), 
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

            Client client = new Client(companyName, contactPersonName) { Address = address};

            AddNewClientPage.AddNewClient(client);

            Verify.AreEqual(string.Format("DemoCompany {0}", uniqueTime),
                                driver.FindElement(By.CssSelector("div.header>h1")).Text,
                    "Company name did not match");
        }
    }
}
