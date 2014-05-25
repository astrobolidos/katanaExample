using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SimpleAuth.Controllers
{
    public class PingController : ApiController
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