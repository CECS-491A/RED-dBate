using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
//using KFC.Red.ManagerLayer.AccessControl;
//using KFC.Red.ManagerLayer.Models;
//using KFC.Red.ManagerLayer.UserManagement;
//using KFC.Red.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static KFC.Red.ServiceLayer.Services.ExceptionService;

namespace KFC.Red.ManagerLayer.Login
{
    public class UserLoginManager
    {
        /*
        UserManagementManager _userManagementManager;
        AuthorizationManager _authorizationManager;
        TokenService _tokenService;

        public LoginManagerResponseDTO LoginFromSSO(
            DatabaseContext _db, string Username, Guid ssoID, string Signature, string PreSignatureString)
        {
            ////////////////////////////////////////
            /// User oAuth at the indivudal application level
            // verify if the login payload is valid via its signature
            _tokenService = new TokenService();
            if (!_tokenService.isValidSignature(PreSignatureString, Signature))
            {
                throw new InvalidTokenSignatureException("Session is not valid.");
            }
            ////////////////////////////////////////

            _userManagementManager = new UserManagementManager();
            var user = _userManagementManager.GetUser(ssoID);
            // check if user does not exist
            if (user == null)
            {
                // create new user
                try
                {
                    user = _userManagementManager.CreateUser(_db, Username, ssoID);
                    _db.SaveChanges();
                }
                catch (InvalidEmailException ex)
                {
                    throw new InvalidEmailException(ex.Message);
                }
                catch (InvalidDbOperationException)
                {
                    _db.Entry(user).State = System.Data.Entity.EntityState.Detached;
                    throw new InvalidDbOperationException("User was not created");
                }
            }
            _authorizationManager = new AuthorizationManager();
            Session session = _authorizationManager.CreateSession(_db, user);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception)
            {
                _db.Entry(session).State = System.Data.Entity.EntityState.Detached;
                throw new InvalidDbOperationException("Session was not created");
            }
            LoginManagerResponseDTO response;
            response = new LoginManagerResponseDTO
            {
                Token = session.Token
            };
            return response;
        }
    }
    */
    }
}
