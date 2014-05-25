
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SimpleAuth.Startup))]
namespace SimpleAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (env, next) =>
            {
                await env.Response.WriteAsync("hello world");
                //await next();
            });
        }

        //private void ConfigureWebApi2(IAppBuilder app)
        //{
        //    var config = new HttpConfiguration();
        //    config.Routes.MapHttpRoute(
        //        "DefaultApi",
        //        "api/{controller}/{id}",
        //        new { id = RouteParameter.Optional });
        //    app.UseWebApi(config);
        //}
    }
}