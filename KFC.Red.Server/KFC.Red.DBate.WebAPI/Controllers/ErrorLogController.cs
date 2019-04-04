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
            ErrorLoggingService ls = new ErrorLoggingService();
            ls.CreateErrorLog();
            return Ok();
        }

        [HttpPost]
        [Route("api/errorlog/createerrorlog")]
        public IHttpActionResult CreateInfoLog()
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            ls.CreateErrorLog();
            return Ok();
        }

        [HttpGet]
        [Route("api/errorlog/displaylogs")]
        public IHttpActionResult DisplayErrorLogs()
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            return Ok();
        }

        [HttpDelete]
        [Route("api/errorlog/deletelog")]
        public IHttpActionResult DeleteErrorLog()
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            //ls.DeleteLog();
            return Ok();
        }

        [HttpGet]
        [Route("api/errorlog/countlog")]
        public IHttpActionResult CountErrorLog()
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            //ls.DeleteLog();
            return Ok("counting message");
        }

    }
}