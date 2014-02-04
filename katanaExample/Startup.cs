using Microsoft.Owin;
using Owin;
using RestSharp;

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
                  env.Response.Write("authenticating: " + env.Request.Path +" \n");
                //await next();
                await next();
            });

            app.Use(async (env, next) =>
            {
                var client = new RestClient("http://en.wikipedia.org/w/api.php?format=json&action=query&titles=Main%20Page&prop=revisions&rvprop=content");
                var request = new RestRequest("", Method.GET);

                var response = client.Execute(request);
                await env.Response.WriteAsync(response.Content);



                //await next();

                //await env.Response.WriteAsync("second middleware");
            });
        }
    }
}