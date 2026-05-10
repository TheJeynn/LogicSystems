using System;
using System.IO;

namespace LogicSystems.Data
{
    public class Logger
    {
        private static Logger? _instance;

        private readonly string logFilePath = "log.txt";

        private Logger() { }

        public static Logger GetInstance()
        {
            if (_instance == null)
                _instance = new Logger();

            return _instance;
        }

        public void Log(string message)
        {
            string logMessage =
                $"{DateTime.Now} - LOG: {message}";

            Console.WriteLine(logMessage);

            File.AppendAllText(
                logFilePath,
                logMessage + Environment.NewLine
            );
        }

        public void Error(string message)
        {
            string errorMessage =
                $"{DateTime.Now} - ERROR: {message}";

            Console.WriteLine(errorMessage);

            File.AppendAllText(
                logFilePath,
                errorMessage + Environment.NewLine
            );
        }
    }
}