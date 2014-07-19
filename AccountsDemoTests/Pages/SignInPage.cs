using AccountsDemoTests.Common;
using OpenQA.Selenium;
using System;

namespace AccountsDemoTests.Pages
{
    public class SignInPage
    {
        private static SignInPage _instance;
        public static SignInPage Instance
        {
            get { return _instance ?? (_instance = new SignInPage()); }
            set { _instance = value; }
        }

        public void SignIn(String userName, String password)
        {
            DriverProvider.Driver.FindElement(By.Id("user_email")).SendKeys(userName);
            DriverProvider.Driver.FindElement(By.Id("user_password")).SendKeys(password);
            DriverProvider.Driver.FindElement(By.Name("commit")).Click();
        }

    }
}
