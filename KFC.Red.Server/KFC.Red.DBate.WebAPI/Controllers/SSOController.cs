using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.ManagerLayer.SSO;
using KFC.RED.DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            if (!ModelState.IsValid || request == null)
            {
                return Content((HttpStatusCode)412, ModelState);
            }
            var lm = new LoginManager();

            Guid userSSOID;
            try
            {
                // check if valid SSO ID format
                userSSOID = Guid.Parse(request.SSOUId);
            }
            catch (Exception)
            {
                return Content((HttpStatusCode)400, "Invalid SSO ID");
            }
            using (var _db = new ApplicationDbContext())
            {
                LoginManagerDTO loginAttempt;
                try
                {
                    loginAttempt = lm.LoginFromSSO(
                        _db,
                        request.Email,
                        userSSOID,
                        request.Signature,
                        request.PreSignatureString());
                }
                catch (Exception e)
                {
                    return Content(HttpStatusCode.Conflict, e.Message);
                }

                LoginResponseDTO response = new LoginResponseDTO
                {
                    //RedirectURI = "http://localhost:8080/#/login?token=" + loginAttempt.Token
                    RedirectURI = "https://thedbateproject.azurewebsites.net/#/login?token=" + loginAttempt.Token
                };

                return Ok(response);
            }
        }
    }
}
