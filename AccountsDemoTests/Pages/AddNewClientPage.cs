using AccountsDemoTests.Common;
using OpenQA.Selenium;
using System;

namespace AccountsDemoTests.Pages
{
    public class AddNewClientPage
    {
        private static AddNewClientPage _instance;
        public static AddNewClientPage Instance
        {
            get { return _instance ?? (_instance = new AddNewClientPage()); }
            set { _instance = value; }
        }

        public void AddNewClient(String companyName, String contactPersonName, String address = "")
        {
            IWebElement clientsLink = DriverProvider.Driver.FindElement(By.CssSelector("nav.navbar"))
                                        .FindElement(By.LinkText("CLIENTS"));
            clientsLink.Click();

            DriverProvider.Driver.FindElement(By.LinkText("+ Add New Client")).Click();

            DriverProvider.Driver.FindElement(By.Id("client_company_name")).SendKeys(companyName);
            DriverProvider.Driver.FindElement(By.Id("client_contact_person_name")).SendKeys(contactPersonName);

            if (address != "")
                DriverProvider.Driver.FindElement(By.Id("client_address")).SendKeys(address);

            DriverProvider.Driver.FindElement(By.Name("commit")).Click();
        }
    }
}
