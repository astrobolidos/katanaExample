using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SimpleAuth.Startup))]
namespace SimpleAuth
{
    public class Startup
    {
    }
}