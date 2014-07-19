using System;

namespace AccountsDemoTests
{
    public class NUnitConsoleRunner
    {
        [STAThread]
        static void Main(string[] args)
        {
            NUnit.ConsoleRunner.Runner.Main(args);
        }

      
    }
}
