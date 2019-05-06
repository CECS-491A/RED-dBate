using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.DTOs;
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

        [HttpGet]
        [Route("api/user/getuseremail/{token}")]
        public IHttpActionResult GetUserEmail(string token)
        {
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
                    return Ok(user.Email);
                }
                catch (Exception ex)
                {
                    return Content(HttpStatusCode.InternalServerError, ex);
                }
            }
        }
    }
}