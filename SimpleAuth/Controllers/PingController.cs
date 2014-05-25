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
            var status = HttpStatusCode.OK;

            return Request.CreateResponse(status, DateTime.Now);
        }
    }
}