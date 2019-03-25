using KFC.Red.Dbate.Logging.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class ErrorLogsController : ApiController
    {
        //Private instance of contact collection
        private ErrorLogsCollection _errorlog = new ErrorLogsCollection();

        [HttpPost]
        [Route("api/errorlogs/listerrors")]
        public IHttpActionResult ListErrors(string errorId)
        {
            _errorlog.GetError(errorId);
            return Ok("list an error");
        }

        [HttpPost]
        [Route("api/errorlogs/listallerrors")]
        public IHttpActionResult ListAllErrors()
        {
            _errorlog.GetAllErrors();
            return Ok("list all error");
        }

        [HttpPost]
        [Route("api/errorlogs/deleteerrors")]
        public IHttpActionResult DeleteError(string errorId)
        {
            _errorlog.DeleteErrors(errorId);
            return Ok("error id deleted");
        }

        [HttpPost]
        [Route("api/errorlogs/deleteallerrors")]
        public IHttpActionResult DeleteAllError()
        {
            _errorlog.DeleteAllErrors();
            return Ok("error id all deleted");
        }

    }
}
