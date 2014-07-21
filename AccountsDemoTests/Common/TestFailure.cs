using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using OpenQA.Selenium;
using AccountsDemoTests.Common;
using NUnit.Framework;

namespace AccountsDemoTests.Common
{
    public class TestFailure
    {
        [ThreadStatic]
        private static List<string> _failures;

        private static List<string> Failures
        {
            get
            {
                if (_failures == null)
                    _failures = new List<string>();
                return _failures;
            }
        }

        private static bool TestFailed
        {
            get { return Failures.Count > 0 ; }
        }

        private static string GetFailureMessages()
        {
            var newLine = Environment.NewLine;
            string failureMessages = newLine + string.Format("Total number of assertions failures: {0}", Failures.Count) + newLine + newLine;

            foreach (string s in Failures)
                failureMessages += s + newLine;

            return failureMessages + newLine;
        }


        // This should be called during [SetUp]
        public static void ClearFailures()
        {
            Failures.Clear();
        }

        // This should be called during [TearDown]
        public static void LogFailureMessagesAndFail()
        {
            if (TestFailed)
            {
                string failureMessages = null;
                try
                {
                    failureMessages = GetFailureMessages();
                }

                catch (Exception e)
                {
                    Verify.Fail("Failure while logging errors: " + e);
                }

                Verify.Fail(failureMessages);
            }
        }


        public static void HandleAssertionException(Exception ae, bool bContinue)
        {
            var exceptionLog = new StringBuilder();

            exceptionLog.AppendLine(DateTime.Now.ToString());
            exceptionLog.AppendLine(ae.Message);

            var screenShotFullPath = TestEnvironment.ScreenShotPath + (Failures.Count + 1) + ".png";
            exceptionLog.Append("ScreenShot Path: " + screenShotFullPath + Environment.NewLine + Environment.NewLine);

            var pageSourceFullPath = TestEnvironment.FileDumpPath + (Failures.Count + 1) + ".html";
            exceptionLog.Append("PageSource Path: " + pageSourceFullPath + Environment.NewLine + Environment.NewLine);

            exceptionLog.Append(GetStackTrace());

            Failures.Add(exceptionLog.ToString());

            CaptureScreenShot(screenShotFullPath);
            CapturePageSource(pageSourceFullPath);

            if (!bContinue)
            {
                throw new Exception(Environment.NewLine + "Test execution halted with below errors:" + Environment.NewLine);
            }
        }

        public static void CaptureScreenShot(string screenShotFullPath)
        {
            var directory = Path.GetDirectoryName(screenShotFullPath);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var driver = DriverProvider.Driver as ITakesScreenshot;
            Screenshot screenshot = driver.GetScreenshot();
            
            File.Delete(screenShotFullPath);
            screenshot.SaveAsFile(screenShotFullPath, ImageFormat.Png);
        }

        public static StringBuilder GetStackTrace()
        {
            var stackTrace = new StackTrace(true);
            var traceAsString = new StringBuilder();

            string myOwnCodeFileName = stackTrace.GetFrame(0).GetFileName();
            foreach (StackFrame stackFrame in stackTrace.GetFrames())
            {
                if ((0 != stackFrame.GetFileLineNumber()) && !myOwnCodeFileName.Equals(stackFrame.GetFileName()))
                {
                    MethodBase method = stackFrame.GetMethod();
                    traceAsString.AppendLine("at " + method.DeclaringType.FullName + "." + method.Name + @" in " +
                                             new FileInfo(stackFrame.GetFileName()).Name + ":line " +
                                             stackFrame.GetFileLineNumber());
                }
            }
            return traceAsString;
        }
        
        public static void CapturePageSource(string pageSourceFullPath)
        {
            var directory = Path.GetDirectoryName(pageSourceFullPath);
            
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
            var driver = DriverProvider.Driver;
            var pagesource = driver.PageSource;
            
            File.Delete(pageSourceFullPath);
            File.WriteAllText(pageSourceFullPath, pagesource);
        }
    }
}