using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace standAlone
{
    public class AssignmentController : ApiController
    {
        public Assigment Get()
        {
            return new Assigment { Id = Guid.NewGuid(), Name = "new assigment" };
        }
    }
}
