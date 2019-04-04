using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFC.Red.ServiceLayer.Logging;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class TelemetryLogController : ApiController
    {
        [HttpPost]
        [Route("api/telemetrylog/createtelemetrylog")]
        public IHttpActionResult CreateTelemetryLog()
        {
            TelemetryLoggingService ls = new TelemetryLoggingService();
            ls.CreateTelemetryLog();
            return Ok("create telemetry logs");
        }

        [HttpGet]
        [Route("api/telemetrylog/displaylogs")]
        public IHttpActionResult DisplayTelemetryLogs()
        {
            TelemetryLoggingService ls = new TelemetryLoggingService();
            return Ok("displaying logs");
        }

        [HttpGet]
        [Route("api/telemetrylog/countlog")]
        public IHttpActionResult CountTelemetryLog()
        {
            TelemetryLoggingService ls = new TelemetryLoggingService();
            //ls.DeleteLog();
            return Ok("counting message");
        }
    }
}
