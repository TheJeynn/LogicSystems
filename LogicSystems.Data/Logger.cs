using System;
using System.IO;

namespace LogicSystems.Data
{
    public class Logger
    {
        private static Logger? _instance;

        private readonly string logFilePath;

        private Logger()
        {
            // Get the base directory where the application runs
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataFilesDir = Path.Combine(baseDirectory, "DataFiles");

            // Create DataFiles directory if it doesn't exist
            if (!Directory.Exists(dataFilesDir))
            {
                Directory.CreateDirectory(dataFilesDir);
            }

            logFilePath = Path.Combine(dataFilesDir, "logs.txt");
        }

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

            try
            {
                File.AppendAllText(
                    logFilePath,
                    logMessage + Environment.NewLine
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        public void Error(string message)
        {
            string errorMessage =
                $"{DateTime.Now} - ERROR: {message}";

            Console.WriteLine(errorMessage);

            try
            {
                File.AppendAllText(
                    logFilePath,
                    errorMessage + Environment.NewLine
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}