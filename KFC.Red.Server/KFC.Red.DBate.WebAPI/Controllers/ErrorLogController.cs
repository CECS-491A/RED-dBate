using KFC.Red.ServiceLayer.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class ErrorLogController : ApiController
    {

        [HttpPost]
        [Route("api/errorlog/createerrorlog")]
        public IHttpActionResult CreateErrorLog()
        {
            LoggingService ls = new LoggingService();
            ls.CreateLog();
            return Ok();
        }

        [HttpGet]
        [Route("api/errorlog/displaylogs")]
        public IHttpActionResult DisplayLogs()
        {
            LoggingService ls = new LoggingService();
            return Ok();
        }

        [HttpDelete]
        [Route("api/errorlog/deletelog")]
        public IHttpActionResult DeleteLog()
        {
            LoggingService ls = new LoggingService();
            //ls.DeleteLog();
            return Ok();
        }

    }
}