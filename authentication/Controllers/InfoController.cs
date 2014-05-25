using System;
using System.Net.Http;
using System.Web.Http;

namespace authentication.Controllers
{
    public class InfoController : ApiController
    {
        //[Authorize]
        public HttpResponseMessage Get()
        {
            var responseContent = new { Id = 1234, Value = "this is a value", Date = DateTime.Now };
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, responseContent);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return response;
        }
    }
}
