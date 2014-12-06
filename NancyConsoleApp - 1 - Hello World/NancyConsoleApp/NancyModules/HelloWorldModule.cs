using System;
using System.Threading.Tasks;
using Nancy;
using NancyConsoleApp.Infrastructure;

namespace NancyConsoleApp.NancyModules
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule(ILog log)
        {
            Before.AddItemToStartOfPipeline(ctx =>
            {
                var message = string.Format("Request received to {0} from {1}", ctx.Request.Url,
                    ctx.Request.UserHostAddress);
                log.Info(message);

                return null;
            });

            OnError.AddItemToStartOfPipeline((ctx, ex) =>
            {
                log.Error(ex.ToString());

                return "Sorry, something is broken!";
            });

            Get["/{name?World}", runAsync: true] = async(_, cancellationToken) => await Task.Run(() => "Hello " + _.Name);
            Get["/break"] = _ =>
            {
                throw new Exception("foobar");
            };
        }
    }
}