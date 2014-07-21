using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace AccountsDemoTests.Common
{
    public class TestEnvironment
    {
        public static string TestName       { get { return TestContext.CurrentContext.Test.Name; } }
        private static string TestFullName  { get { return TestContext.CurrentContext.Test.FullName; } }
        public static TestStatus TestStatus  { get { return TestContext.CurrentContext.Result.Status; } }

        public static string TestFixtureName()
        {
            var strings = TestFullName.Split('.');
            return strings[strings.Length - 2];
        }

        public static string NameSpaceName()
        {
            var strings = TestFullName.Split('.');
            return strings[strings.Length - 3];
        }
        
        public static string AssemblyPath {
            get {
                    string fullPath = Assembly.GetCallingAssembly().GetName().CodeBase;
                    return Path.GetDirectoryName(fullPath).Substring(6);
                }
        }

        public static string ScreenShotPath {
            get {
                    return AssemblyPath + 
                            "\\TestResults\\ScreenShots\\" + NameSpaceName() + "\\" + TestFixtureName() + "\\" + TestName + "\\";
                }
        }

		public static string FileDumpPath
		{
			get
			{
				return AssemblyPath +
							"\\TestResults\\FileDumps\\" + NameSpaceName() + "\\" + TestFixtureName() + "\\" + TestName + "\\";
			}
		}

    }
}