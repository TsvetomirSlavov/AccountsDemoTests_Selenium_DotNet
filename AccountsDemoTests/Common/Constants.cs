using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.Threading;


namespace AccountsDemoTests.Common
{
    public class Constants
    {
        static Configuration config = ConfigurationManager.OpenExeConfiguration(TestEnvironment.AssemblyPath + "\\" +
            System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location)); 

        public static readonly string APPLICATION_URL =
            new Uri(config.AppSettings.Settings["applicationRootUrl"].Value).AbsoluteUri;

        public static readonly string USER_EMAIL =
            config.AppSettings.Settings["userEmail"].Value;

        public static readonly string USER_PASSWORD =
            config.AppSettings.Settings["userPassword"].Value;

        public static string BROWSER = config.AppSettings.Settings["browser"].Value;
        

    }
}
