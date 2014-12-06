using System;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Hosting;
using Owin;

namespace NancyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var app = WebApp.Start("http://localhost:91/", appBuilder => appBuilder.UseNancy()))
            {
                Console.WriteLine("Nancy host started");

                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    //wait
                }

                Console.WriteLine("Nancy host stopping");
            }
        }
    }
}
