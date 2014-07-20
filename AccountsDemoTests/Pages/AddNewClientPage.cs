using AccountsDemoTests.Common;
using AccountsDemoTests.Entities;
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

        public void AddNewClient(Client client)
        {
            IWebElement clientsLink = DriverProvider.Driver.FindElement(By.CssSelector("nav.navbar"))
                                        .FindElement(By.LinkText("CLIENTS"));
            clientsLink.Click();

            DriverProvider.Driver.FindElement(By.LinkText("+ Add New Client")).Click();

            FillClientData(client);

            DriverProvider.Driver.FindElement(By.Name("commit")).Click();
        }

        private static void FillClientData(Client client)
        {
            DriverProvider.Driver.FindElement(By.Id("client_company_name")).SendKeys(client.CompanyName);
            DriverProvider.Driver.FindElement(By.Id("client_contact_person_name")).SendKeys(client.ContactPersonName);

            if (client.Address != null)
                DriverProvider.Driver.FindElement(By.Id("client_address")).SendKeys(client.Address);
            if (client.PhoneNumber != null)
                DriverProvider.Driver.FindElement(By.Id("client_address")).SendKeys(client.PhoneNumber);
            if (client.PhoneNumber2 != null)
                DriverProvider.Driver.FindElement(By.Id("client_address")).SendKeys(client.PhoneNumber2);
            if (client.Email != null)
                DriverProvider.Driver.FindElement(By.Id("client_address")).SendKeys(client.Email);
            if (client.Email2 != null)
                DriverProvider.Driver.FindElement(By.Id("client_address")).SendKeys(client.Email2);
        }
    }
}
