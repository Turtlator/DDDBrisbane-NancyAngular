using System;
using System.Threading.Tasks;
using Nancy;

namespace NancyConsoleApp.NancyModules
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule(ILog log) : base("hello")
        {
            Before.AddItemToStartOfPipeline(ctx =>
            {
                log.Info("Request received from " + ctx.Request.UserHostAddress + " to " + ctx.Request.Url);

                return null;
            });

            OnError.AddItemToStartOfPipeline((ctx, ex) =>
            {
                log.Error(ex.ToString());

                return "It's broken :(";
            });

            Get["/{name?World}", true] = async (_, token) => await Task.Run(() => "Hello " + _.Name);
            Get["/break"] = _ =>
            {
                throw new InvalidOperationException("it's all broked");
            };
        }
    }
}