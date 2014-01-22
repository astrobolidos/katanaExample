using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace standAlone
{
    using System.IO;
    using System.Web.Http;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:1978";

            using (WebApp.Start(uri))
            {
                Console.WriteLine("Started!");
                Console.ReadKey();
                Console.WriteLine("Stopping...");
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //logging middleware
            app.Use(async (environment, next) => {
                foreach (var pair in environment.Environment)
                {
                    Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
                }
                await next();

                Console.WriteLine(environment.Response.Headers["Authorization"]);
            });

            //path logging middleware
            app.Use(async (env, next) => {
                Console.WriteLine("Requesting " + env.Request.Path);
                await next();
                Console.WriteLine("Response status code: " + env.Response.StatusCode);
            });

            //web api middleware configuration
            ConfigureWebApi(app);

            // hello world middleware configuration
            app.UseHelloWord();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi", 
                "api/{controller}/{id}", 
                new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWord(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }  
    }

    /// <summary>
    /// Also known as middle ware.
    /// </summary>
    public class HelloWorldComponent
    {
        public AppFunc _next { get; set; }
        public HelloWorldComponent(AppFunc next)
        {
            this._next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            environment["owin.ResponseStatusCode"] = 201;
            (environment["owin.ResponseHeaders"] as IDictionary<string, string[]>)["Authorization"] = new string[] { "my auth code" };

            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!! using component"); 
            }
        }
    }
}
