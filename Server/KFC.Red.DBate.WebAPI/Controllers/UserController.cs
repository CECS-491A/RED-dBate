using KFC.Red.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace KFC.Red.DBate.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        /*
        UserLoginManager _userLoginManager;

        // POST api/user/login
        [HttpPost]
        [Route("api/user/login")]
        public IHttpActionResult LoginFromSSO([FromBody] LoginDTO requestPayload)
        {
            if (!ModelState.IsValid || requestPayload == null)
            {
                return Content((HttpStatusCode)412, ModelState);
            }
            _userLoginManager = new UserLoginManager();
            Guid userSSOID;
            try
            {
                // check if valid SSO ID format
                userSSOID = Guid.Parse(requestPayload.SSOUserId);
            }
            catch (Exception)
            {
                return Content((HttpStatusCode)400, "Invalid SSO ID");
            }
            using (var _db = new ApplicationDbContext())
            {
                LoginManagerResponseDTO loginAttempt;
                try
                {
                    loginAttempt = _userLoginManager.LoginFromSSO(
                        _db,
                        requestPayload.Email,
                        userSSOID,
                        requestPayload.Signature,
                        requestPayload.PreSignatureString());
                }
                catch (InvalidTokenSignatureException ex)
                {
                    return Content((HttpStatusCode)401, ex.Message);
                }
                catch (InvalidDbOperationException ex)
                {
                    return Content((HttpStatusCode)500, ex.Message);
                }
                catch (InvalidEmailException ex)
                {
                    return Content((HttpStatusCode)400, ex.Message);
                }
                LoginResponseDTO response = new LoginResponseDTO
                {
                    RedirectURI = "home" + loginAttempt.Token
                };
                return Ok(response);
            }
        }
        */
    }
}