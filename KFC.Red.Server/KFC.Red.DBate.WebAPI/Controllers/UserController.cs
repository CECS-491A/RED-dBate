using KFC.Red.DataAccessLayer.Data;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.SessionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        public string GetHeader(object request, string header)
        {
            IEnumerable<string> headerValues;
            var nameFilter = string.Empty;
            if (Request.Headers.TryGetValues(header, out headerValues))
            {
                nameFilter = headerValues.FirstOrDefault();
            }
            return nameFilter;
        }

        [HttpGet]
        [Route("api/user/getuser")]
        public IHttpActionResult GetUser()
        {
            var token = GetHeader(Request, "Token");
            if (token.Length < 1)
            {
                return Content(HttpStatusCode.Unauthorized, "No token provided.");
            }
            using (var _db = new ApplicationDbContext())
            {
                SessionServ _sessionService = new SessionServ();
                try
                {
                    var session = _sessionService.GetSession(_db,token);
                    if (session == null)
                    {
                        return Content(HttpStatusCode.NotFound, "Session is no longer available.");
                    }
                    UserManager _userManager = new UserManager();

                    var user = _userManager.GetUser(session.UId);
                    return Ok(new
                    {
                        id = user.ID,
                        username = user.Email,
                        disabled = user.IsAccountActivated,
                    });
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.InternalServerError, ex);
                }
            }
        }
    }
}