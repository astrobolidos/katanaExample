using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace standAlone
{
    using System.IO;
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
            });

            //path logging middleware
            app.Use(async (env, next) => {
                Console.WriteLine("Requesting " + env.Request.Path);
                await next();
                Console.WriteLine("Response status code: " + env.Response.StatusCode);
            });

            app.UseHelloWord();
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
            var responseStatus = environment["owin.ResponseStatusCode"] = 201;


            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!! using component"); 
            }
        }
    }
}
