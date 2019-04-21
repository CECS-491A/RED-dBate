using KFC.Red.ServiceLayer.Logging;
using System.Collections.Generic;
using System.Web.Http;
using KFC.Red.ManagerLayer.Logging;
using System.Threading.Tasks;
using MongoDB.Bson;
using KFC.Red.DataAccessLayer.DTOs;
using System.Web.Http.Cors;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TelemetryLogController : ApiController
    {
        public  class LocationRequest
        {
            public string Token { get; set; }
            public string Ip { get; set; }
            public string Location { get; set; }
        }

        //MIGHT NOT BE NEEDED
        [HttpPost]
        [Route("api/telemetrylog/createtelemetrylog")]
        public IHttpActionResult CreateTelemetryLog([FromBody] LocationRequest req)
        {
            TelemetryLoggingManager tlm = new TelemetryLoggingManager();
            tlm.CreateTelemetryLog(req.Token, req.Ip, req.Location);
            return Ok("telemetry log created");
        }

        [HttpGet]
        [Route("api/telemetrylog/displaylogs")]
        public async Task<List<TelemetryLogDTO>> DisplayTelemetryLogsAsync()
        {
            TelemetryLoggingManager element = new TelemetryLoggingManager();
            var documents = element.DisplayTelemetryLogsAsync();

            return await documents;
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