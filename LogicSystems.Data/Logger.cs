using System;
using System.IO;

namespace LogicSystems.Data
{
    public sealed class Logger
    {
        private static Logger? _instance;
        private static readonly object _lock = new object();

        private Logger() { }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            string log = $"{DateTime.Now}: {message}";

            Console.WriteLine(log);

            File.AppendAllText("logs.txt", log + Environment.NewLine);
        }

        public void Error(string message)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [ERROR] {message}");
        }
    }
}