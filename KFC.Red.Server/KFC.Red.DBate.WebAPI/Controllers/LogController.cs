using System.Collections.Generic;
using System.Web.Http;
using KFC.Red.ManagerLayer.Logging;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.DTOs;
using MongoDB.Bson;
using System;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class LogController : ApiController
    {
        /// <summary>
        /// Controller for getting the IP Adrress from the front end.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/log/createtelemetrylogs2")]
        public IHttpActionResult IpAddress()
        {
            LoggingManager<TelemetryLog2DTO> loggerManager = new LoggingManager<TelemetryLog2DTO>();
            loggerManager.CreateTelemetryLog2();
            return Ok("tlog 2 created");
        }

        /// <summary>
        ///  Controller for creating the telemetry logs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/log/createtelemetrylogs")]
        public IHttpActionResult CreateTelemetryLog()
        {
            LoggingManager<TelemetryLogDTO> loggerManager = new LoggingManager<TelemetryLogDTO>();
            loggerManager.CreateTelemetryLog();
            return Ok("telemetry log created");
        }

        /// <summary>
        ///  Controller for display the error logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/log/displayerrorlogs")]
        public async Task<List<ErrorLogDTO>> DisplayLogsAsync()
        {
            LoggingManager<ErrorLogDTO> loggerManager =  new LoggingManager<ErrorLogDTO>();
            var documents = loggerManager.DisplayLogsAsync("ErrorLogs");
            return await documents;
        }


        /// <summary>
        ///  Controller for display the telemeytry logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/log/displaytelemetrylogs2")]
        public async Task<List<TelemetryLog2DTO>> DisplayLogsAsyncTelemetry2()
        {
            LoggingManager<TelemetryLog2DTO> loggerManager = new LoggingManager<TelemetryLog2DTO>();
            var documents = loggerManager.DisplayLogsAsync("TelemetryLogs2");
            return await documents;
        }


        /// <summary>
        ///  Controller for display the telemeytry logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/log/displaytelemetrylogs")]
        public async Task<List<TelemetryLogDTO>> DisplayLogsAsyncTelemetry()
        {
            LoggingManager<TelemetryLogDTO> loggerManager = new LoggingManager<TelemetryLogDTO>();
            var documents = loggerManager.DisplayLogsAsync("TelemetryLogs");
            return await documents;
        }

        /// <summary>
        /// Controller to delete error logs
        /// </summary>
        /// <param name="id">log id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/log/deletelog")]
        public IHttpActionResult DeleteLog(string id)
        {
            string collectionName = "ErrorLogs";
            LoggingManager<BsonDocument> loggerManager = new LoggingManager<BsonDocument>();
            try
            {
                loggerManager.DeleteLog(id,collectionName);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
