using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.SSO;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.RED.DataAccessLayer.DTOs;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SSOController : ApiController
    {
        [HttpPost]
        [Route("api/sso/login")]
        public IHttpActionResult SsoLogin([FromBody] LoginDTO request)
        {
            try
            {
                var ssoLoginManager = new SSO_Manager();
                var ssoId = new Guid(request.SSOUserId);

                var loginSession = ssoLoginManager.LoginFromSSO(
                    request.Email,
                    ssoId);
                var redirectURL = "http://localhost:8080/#/login/?token=" + loginSession.Token;
                return Redirect(redirectURL);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, "An Error Occured: " + e.Message + e.TargetSite + e.Source);
            }
        }

        [HttpPost]
        [Route("api/sso/logout")]
        public IHttpActionResult Logout([FromBody] LogoutDTO req)
        {
            var sessionManager = new SessionManager();
            try
            {
                var lm = new LoggingManager<TelemetryLogDTO>();
                lm.CreateTelemetryLog(req.Token);
                sessionManager.DeleteSession(req.Token);


                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message + e.TargetSite + e.Source + e.StackTrace + e.InnerException);
            }
        }

        //NEED TO FIX
        [HttpPost]
        [Route("api/user/delete")]
        public IHttpActionResult DeleteFromSSO([FromBody] LoginDTO request)
        {

            try
            {
                var sessionManager = new SessionManager();
                var ssoManager = new SSO_Manager();
                var userManager = new UserManager();

                var user = userManager.GetUser(request.SSOUserId);

                if (user == null)
                {
                    return Ok("User doesn't exist");
                }

                var sessionDeleted = sessionManager.DeleteSessions(Guid.Parse(request.SSOUserId));
                var userDeleted = userManager.DeleteUser(user);

                return Ok("User deleted from DBate and SSO");

            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.NotImplemented, e.Message);
            }
        }

        [HttpGet]
        [Route("api/sso/health")]
        public IHttpActionResult HealthCheck()
        {
            using (var _db = new ApplicationDbContext())
            {
                try
                {
                    if (_db.Database.Exists())
                    {
                        return Ok("DBate is working properly");
                    }

                    return Content(HttpStatusCode.InternalServerError, "An Error has been encountered");

                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.InternalServerError, e.Message);
                }
            }
        }
    }
}