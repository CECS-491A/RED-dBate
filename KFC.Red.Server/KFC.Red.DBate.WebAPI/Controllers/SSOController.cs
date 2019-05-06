using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.SSO;
using KFC.RED.DataAccessLayer.DTOs;
using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using KFC.Red.ServiceLayer.Logging;
using MongoDB.Driver;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SSOController : ApiController
    {
        [HttpPost]
        [Route("api/sso/login")]
        public IHttpActionResult SsoLogin([FromBody] LoginDTO request)
        {
            string redirectURL = "http://localhost:8080/#/login/?token=";
            using (var _db = new ApplicationDbContext())
            {
                try
                {
                    var ssoLoginManager = new SSO_Manager();
                    var ssoId = new Guid(request.SSOUserId);

                    var loginSession = ssoLoginManager.LoginFromSSO(
                        request.Email,
                        ssoId,
                        request.Timestamp,
                        request.Signature);
                    redirectURL = "http://localhost:8080/#/login/?token=" + loginSession.Token;
                    return Redirect(redirectURL);
                }
                catch (Exception)
                {
                    return Content(HttpStatusCode.Conflict, "An Error Occured");
                }
            }
        }
        
        [HttpPost]
        [Route("api/sso/logout")]
        public async IHttpActionResult Logout([FromBody] LogoutDTO req)
        {
            using (var _db = new ApplicationDbContext())
            {
                SessionManager sessionManager = new SessionManager();
                LoggingService<TelemetryLogDTO> logserve = new LoggingService<TelemetryLogDTO>("TelemetryLog");
                try
                {
                    var collection = logserve.documents.GetCollection<TelemetryLogDTO>("TelemetryLog");
                    var query =
                        collection.AsQueryable<TelemetryLogDTO>()
                        .Where(e => e.Token == req.Token)
                        .Select(e => e); // this trivial projection is optional when using lambda syntax

                    if (query == null)
                    {
                        var lm = new LoggingManager<TelemetryLogDTO>();
                        lm.CreateTelemetryLog(req.Token, "", "IP NULL");
                    }
                    /*
                    else
                    {
                        query = await collection.FindOneAndUpdate(
                                Builders<BsonDocument>.Filter.Eq("userLogout", req.Token),
                                Builders<BsonDocument>.Update.Set("userLogout", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"))
                                );
                    }*/

                    sessionManager.DeleteSession(req.Token);
                    _db.SaveChanges();

                    return Ok();
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.Conflict, e.Message);
                }
            }
        }

        [HttpGet]
        [Route("api/sso/health")]
        public IHttpActionResult HealthCheck()
        {
            using(var _db = new ApplicationDbContext())
            {
                if (_db.Database.Exists())
                {
                    return Ok("DBate is working properly");
                }

                return Content(HttpStatusCode.InternalServerError, "An Error has been encountered");
            }
        }
    }
}
