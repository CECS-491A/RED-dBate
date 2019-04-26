using System.Collections.Generic;
using System.Web.Http;
using KFC.Red.ManagerLayer.Logging;
using System.Threading.Tasks;
using KFC.RED.DataAccessLayer.DTOs;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class LogController : ApiController
    {
        [HttpGet]
        [Route("api/log/displaylogs")]
        public async Task<List<LogDTO>> DisplayLogsAsync()
        {
            LoggingManager elm = new LoggingManager();
            var documents = elm.DisplayLogsAsync();
            return await documents;
        }

        [HttpDelete]
        [Route("api/log/deletelog")]
        public IHttpActionResult DeleteErrorLog(string id)
        {
            LoggingManager elm = new LoggingManager();
            try
            {
                elm.DeleteLog(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }


    }
}
