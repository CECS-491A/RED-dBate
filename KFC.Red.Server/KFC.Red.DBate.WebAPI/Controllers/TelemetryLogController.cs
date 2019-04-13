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
    public class TelemetryLogController : ApiController
    {

        //MIGHT NOT BE NEEDED
        [HttpGet]
        [Route("api/telemetrylog/createtelemetrylog")]
        public IHttpActionResult CreateTelemetryLog()
        {
            TelemetryLoggingService ls = new TelemetryLoggingService();
            ls.CreateTelemetryLog();
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