using System.Collections.Generic;
using System.Web.Http;
using KFC.Red.ManagerLayer.Logging;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.DTOs;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class ErrorLogController : ApiController
    {

        [HttpGet]
        [Route("api/errorlog/displaylogs")]
        public async Task<List<ErrorLogDTO>> DisplayErrorLogsAsync()
        {
            ErrorLoggingManager elm = new ErrorLoggingManager();
            var documents = elm.DisplayErrorLogsAsync();

            return await documents;
        }

        [HttpDelete]
        [Route("api/errorlog/deletelog")]
        public IHttpActionResult DeleteErrorLog(string id)
        {
            ErrorLoggingManager elm = new ErrorLoggingManager();
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