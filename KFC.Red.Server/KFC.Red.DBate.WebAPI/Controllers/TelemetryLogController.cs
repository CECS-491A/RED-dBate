using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class TelemetryLogController : ApiController
    {
        [HttpPost]
        [Route("api/telemetrylog/createtelemetrylog")]
        public IHttpActionResult CreateTelemetryLog()
        {
            TelemetryLoggingService ls = new TelemetryLoggingService();
            //ls.CreateTelemetryLog();
            return Ok("create telemetry logs");
        }

        [HttpGet]
        [Route("api/telemetrylog/displaylogs")]
        public async System.Threading.Tasks.Task<List<TelemetryLogDTO>> DisplayErrorLogsAsync()
        {
            TelemetryLogs t = new TelemetryLogs();
            TelemetryLoggingService ls = new TelemetryLoggingService();
            var collection = ls.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            //var documents = await ls._tlogCollection.Find(new BsonDocument()).ToListAsync();
            //return documents;
            return null;
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
