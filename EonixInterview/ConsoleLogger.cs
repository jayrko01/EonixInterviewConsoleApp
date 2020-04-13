using System;
using System.Collections.Generic;
using System.Text;

namespace EonixInterview
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string message = "")
        {
            Console.WriteLine(message);
        }
    }
}
