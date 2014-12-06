using System;

namespace NancyConsoleApp.Infrastructure
{
    public interface ILog
    {
        void Info(string message);
        void Error(string message);
    }

    public class ConsoleLog : ILog
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}