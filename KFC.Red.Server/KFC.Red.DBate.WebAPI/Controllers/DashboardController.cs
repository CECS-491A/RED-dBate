using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class DashboardController : ApiController
    {
        [HttpPost]
        [Route("api/uad/dashboard")]
        public IHttpActionResult UADashboard()
        {

            return Ok("usage analysis dashboard is displayed");
        }
    }
}
