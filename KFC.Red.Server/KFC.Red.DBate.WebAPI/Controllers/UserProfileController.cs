using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

using KFC.Red.ManagerLayer.UserProfile;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.DataAccessLayer.DTOs;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]  // copied and pasted from QuestionController, not sure if needed
    public class UserProfileController : ApiController
    {
        [HttpGet]
        [Route("api/userprofile/displayuser")]
        public IHttpActionResult DisplayUser([FromBody] UserProfileDTO userProfileDTO)
        {
            var sessionManager = new SessionManager();      // created because only sessions are stored in front end
            var userProfileManager = new UserProfileManager();  // object that uses GetUserInfo method

            try
            {
                // missing error handling?
                var session = sessionManager.GetSession(userProfileDTO.Token);  // holds user session, which holds user ID
                return Ok(userProfileManager.GetUserInfo(session.UId));     // returns user info
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
        }
    }
}