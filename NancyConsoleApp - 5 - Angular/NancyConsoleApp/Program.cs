using System;
using Microsoft.Owin.Hosting;
using Owin;

namespace NancyConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var webApp = WebApp.Start("http://localhost:91", appBuilder => appBuilder.UseNancy()))
            {
                Console.WriteLine("Nancy Host Started");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    //wait
                }

                Console.WriteLine("Nancy Host Stopping");
            }
        }
    }
}