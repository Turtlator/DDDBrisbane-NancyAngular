using Nancy;

namespace NancyConsoleApp.NancyModules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["App.html"];
        }
    }
}