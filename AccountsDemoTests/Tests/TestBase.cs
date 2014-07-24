using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AccountsDemoTests.Common;
using AccountsDemoTests.Pages;

namespace AccountsDemoTests.Tests
{
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver driver;

        public SignInPage SignInPage;
        public AddNewClientPage AddNewClientPage;

        [SetUp]
        protected void SetUp()
        {
            driver = new DriverInitializer().Initialize();

            SignInPage = SignInPage ?? SignInPage.Instance;
            AddNewClientPage = AddNewClientPage ?? AddNewClientPage.Instance;

            TestFailure.ClearFailures();

        }

        [TearDown]
        protected void TearDown()
        {
            // If test has failed due to an unhandled exception
            if (TestEnvironment.TestStatus.Equals(TestStatus.Failed))
            {
                TestFailure.CaptureScreenShot(TestEnvironment.ScreenShotPath + "UnExpectedFailure.png");
                TestFailure.CapturePageSource(TestEnvironment.FileDumpPath + "UnExpectedFailure.html");
            }

            // If test has failed due to assertion failures
            TestFailure.LogFailureMessagesAndFail();
            driver.Quit();
        }
    }
}
