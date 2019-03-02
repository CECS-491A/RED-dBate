using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    //[EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Hello()
        {
            return "Hello World " + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        }

    }
}
