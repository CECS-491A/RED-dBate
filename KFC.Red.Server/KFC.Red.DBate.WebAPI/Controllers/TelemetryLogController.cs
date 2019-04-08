using KFC.Red.ServiceLayer.Logging;
using KFC.RED.DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using MongoDB.Driver.Linq;
using KFC.RED.DataAccessLayer.DTOs;

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
        public async System.Threading.Tasks.Task<List<TelemetryLogDTO>> DisplayErrorLogsAsync()
        {
            TelemetryLogs t = new TelemetryLogs();
            ErrorLoggingService ls = new ErrorLoggingService();
            var collection = ls.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await ls._logCollection.Find(new BsonDocument()).ToListAsync();

            return documents;
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
