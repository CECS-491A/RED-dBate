using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CECS491_DBate.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}
