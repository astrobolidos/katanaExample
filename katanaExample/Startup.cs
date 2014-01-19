using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(katanaExample.Startup))]
namespace katanaExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //path logging middleware
            app.Use(async (env, next) =>
            {
                Console.WriteLine("Requesting " + env.Request.Path);
                await env.Response.WriteAsync("hello world");
            });
        }
    }
}