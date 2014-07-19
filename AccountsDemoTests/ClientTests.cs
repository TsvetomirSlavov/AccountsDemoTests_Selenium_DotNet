using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AccountsDemoTests
{
    [TestFixture]
    public class ClientTests : TestBase
    {
        [Test]
        public void UserCanCreateClientOnlyWithMandatoryFieldsSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            Login("account1@ad.com", "password");

            IWebElement clientsLink = driver.FindElement(By.CssSelector("nav.navbar"))
                                        .FindElement(By.LinkText("CLIENTS"));
            clientsLink.Click();

            driver.FindElement(By.LinkText("+ Add New Client")).Click();

            String uniqueTime = DateTime.Now.ToString("ddMMyyhhmmssffff");
            driver.FindElement(By.Id("client_company_name")).
                SendKeys(String.Format("DemoCompany {0}", uniqueTime));

            driver.FindElement(By.Id("client_contact_person_name")).
                SendKeys(String.Format("Contact Person {0}", uniqueTime));

            driver.FindElement(By.Name("commit")).Click();

            Assert.AreEqual(string.Format("DemoCompany {0}", uniqueTime), 
                                driver.FindElement(By.CssSelector("div.header>h1")).Text,
                    "Company name did not match");
        }

        [Test]
        public void UserCanCreateClientWithAddressSuccessfully()
        {
            driver.Navigate().GoToUrl("http://accountsdemo.herokuapp.com/");
            Login("account1@ad.com", "password");

            IWebElement clientsLink = driver.FindElement(By.CssSelector("nav.navbar"))
                                        .FindElement(By.LinkText("CLIENTS"));
            clientsLink.Click();

            driver.FindElement(By.LinkText("+ Add New Client")).Click();

            String uniqueTime = DateTime.Now.ToString("ddMMyyhhmmssffff");
            driver.FindElement(By.Id("client_company_name")).
                SendKeys(String.Format("DemoCompany {0}", uniqueTime));

            driver.FindElement(By.Id("client_contact_person_name")).
                SendKeys(String.Format("Contact Person {0}", uniqueTime));

            driver.FindElement(By.Id("client_address")).
                SendKeys(String.Format("Client Full Address {0}", uniqueTime));


            driver.FindElement(By.Name("commit")).Click();

            Assert.AreEqual(string.Format("DemoCompany {0}", uniqueTime),
                                driver.FindElement(By.CssSelector("div.header>h1")).Text,
                    "Company name did not match");
        }

    }
}
