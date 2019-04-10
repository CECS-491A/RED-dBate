using KFC.Red.ServiceLayer.Logging;
using System.Collections.Generic;
using System.Web.Http;
using KFC.RED.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class ErrorLogController : ApiController
    {
        public class ErrorLogRequest
        {
            public string id { get; set; }
        }


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
        public async Task<List<ErrorLogDTO>> DisplayErrorLogsAsync()
        {
            ErrorLoggingManager elm = new ErrorLoggingManager();
            var documents = elm.DisplayErrorLogsAsync();

            return await documents;
        }

        [HttpPost]
        [Route("api/errorlog/deletelog")]
        public IHttpActionResult DeleteErrorLog([FromBody] ErrorLogRequest Request)
        {
            /*
            ErrorLoggingManager elm = new ErrorLoggingManager();
            elm.DeleteLog(Request.id);

            return Ok("ll");
            */
            ErrorLoggingService el = new ErrorLoggingService();
            try
            {
                //Mongo Query  
                //var carObjectid = Query<CarModel>.EQ(p => p.Id, new ObjectId(Request.id));
                // Document Collections  
                //var collection = el.database.GetCollection<ErrorLogDTO>("CustomLog1");
                // Document Delete which need ObjectId to Delete Data   
                //var result = collection.//collection.Remove(carObjectid, RemoveFlags.Single);

                //return RedirectToAction("Index");
            }
            catch
            {
                //return View();
            }
            return null;
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