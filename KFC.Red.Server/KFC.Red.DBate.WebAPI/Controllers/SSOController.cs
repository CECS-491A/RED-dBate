using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.SSO;
using System;
using System.Net;
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
            string redirectURL = "http://localhost:8080/#/login/?token=";
            using (var _db = new ApplicationDbContext())
            {
                try
                {
                    var ssoLoginManager = new LoginManager();
                    var ssoId = new Guid(request.SSOUserId);
                    // user will get logged in or registered
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

        //still have to implement
        [HttpGet]
        [Route("api/sso/logout")]
        public IHttpActionResult Logout()
        {
            return null;
        }
    }
}
