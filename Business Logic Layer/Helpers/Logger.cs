using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Helpers
{
    // Logger class with Singleton pattern and file logging
    public class Logger
    {
        // Private static instance of Logger
        private static readonly Logger _instance = new Logger();

        // File path for log storage
        private readonly string _logFilePath = "logs.txt";

        // Private constructor to prevent instantiation
        private Logger()
        {
            // Ensure the log file exists
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Dispose();
            }
        }

        // Public static property to access the single instance
        public static Logger Instance => _instance;

        // Method to log messages to the console and file
        public void Log(string message)
        {
            string logMessage = $"[{DateTime.Now}] {message}";

            // Log to console
            Console.WriteLine(logMessage);

            // Append log to file
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}
