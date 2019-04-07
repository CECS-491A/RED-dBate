using KFC.Red.ServiceLayer.Logging;
using KFC.RED.DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
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
    public class ErrorLogController : ApiController
    {

        //MIGHT NOT BE NEEDED
        [HttpPost]
        [Route("api/errorlog/createerrorlog")]
        public IHttpActionResult CreateErrorLog()
        {
            ErrorLoggingService ls = new ErrorLoggingService();
            ls.CreateErrorLog();
            return Ok();
        }

        [HttpGet]
        [Route("api/errorlog/displaylogs")]
        public async System.Threading.Tasks.Task<List<ErrorLogDTO>> DisplayErrorLogsAsync()
        {
            ErrorLogs e = new ErrorLogs();
            ErrorLoggingService ls = new ErrorLoggingService();
            var collection = ls.GetCollection("CustomLog1");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            var documents = await ls._logCollection.Find(new BsonDocument()).ToListAsync();
            
            return documents;
        }

        HttpResponseMessage ToJson(BsonDocument document)
        {
            return new HttpResponseMessage { Content = new StringContent(document.ToJson(), System.Text.Encoding.UTF8, "application/json") };
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