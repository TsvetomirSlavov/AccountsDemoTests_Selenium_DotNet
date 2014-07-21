using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AccountsDemoTests.Common
{
    public class Verify
    {
        public static void AreEqual(object expected, object actual, string message, bool bContinue = true)
        {
            try
            {
                Assert.AreEqual(expected, actual, message);
            }
            catch (AssertionException ae)
            {
                TestFailure.HandleAssertionException(ae, bContinue);                
            }
        }

        public static void That(object actual, IResolveConstraint expected, string message, bool bContinue = true)
        {
            try
            {
                Assert.That(actual, expected, message);
            }
            catch (AssertionException ae)
            {
                TestFailure.HandleAssertionException(ae, bContinue);
            }
        }

        public static void True(bool condition, string message, bool bContinue = true)
        {
            try
            {
                Assert.IsTrue(condition, message);
            }
            catch (AssertionException ae)
            {
                TestFailure.HandleAssertionException(ae, bContinue);
            }
        }

        public static void Fail(string message)
        {
            Assert.Fail(message);
        }
    }
}