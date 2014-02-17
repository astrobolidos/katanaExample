using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(katanaExample.Startup))]
namespace katanaExample
{
    //http://www.asp.net/aspnet/overview/owin-and-katana/owin-middleware-in-the-iis-integrated-pipeline
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //authenticaction middleware
            app.Use(async (env, next) =>
            {
                await env.Response.WriteAsync("hello world");
                await next();
            });

            app.Use(async (env, next) => {
                await env.Response.WriteAsync("second middleware");
                //await next();
            });
        }
    }
}