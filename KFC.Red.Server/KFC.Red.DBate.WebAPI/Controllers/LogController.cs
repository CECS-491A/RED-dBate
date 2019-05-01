using System.Collections.Generic;
using System.Web.Http;
using KFC.Red.ManagerLayer.Logging;
using System.Threading.Tasks;
using KFC.RED.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.DTOs;
using MongoDB.Bson;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class LogController : ApiController
    {
        /// <summary>
        /// Controller for creating the error logs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/log/createerrorlogs")]
        public IHttpActionResult CreateErrorLog()
        {
            LoggingManager<TelemetryLogDTO> errorlogman = new LoggingManager<TelemetryLogDTO>();
            errorlogman.CreateErrorLog();
            return Ok("error log created");
        }

        /// <summary>
        /// Controller for getting the IP Adrress from the front end.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/log/ipaddress")]
        public IHttpActionResult IpAddress()
        {
            LoggingManager<TelemetryLogDTO> errorlogman = new LoggingManager<TelemetryLogDTO>();
            errorlogman.CreateErrorLog();
            return Ok("ip address retrieved");
        }

        /// <summary>
        ///  Controller for creating the telemetry logs
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/log/createtelemetrylogs")]
        public IHttpActionResult CreateTelemetryLog()
        {
            LoggingManager<TelemetryLogDTO> telelogman = new LoggingManager<TelemetryLogDTO>();
            telelogman.CreateTelemetryLog();
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
            LoggingManager<ErrorLogDTO> elm =  new LoggingManager<ErrorLogDTO>();
            var documents = elm.DisplayLogsAsync("ErrorLogs");
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
            LoggingManager<TelemetryLogDTO> elm = new LoggingManager<TelemetryLogDTO>();
            var documents = elm.DisplayLogsAsync("TelemetryLogs");
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
            LoggingManager<BsonDocument> elm = new LoggingManager<BsonDocument>();
            try
            {
                elm.DeleteLog(id,collectionName);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
