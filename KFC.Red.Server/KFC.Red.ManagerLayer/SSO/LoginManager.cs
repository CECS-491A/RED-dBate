using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.TokenService;
using KFC.RED.DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.SSO
{
    public class LoginManager
    {
        SessionManager sm;
        UserManager um;
        TokenService ts;
        LoginDTO ldto;

        public LoginManager()
        {
            sm = new SessionManager();
            um = new UserManager();
            ts = new TokenService();
            ldto = new LoginDTO();
        }

        public LoginManagerDTO LoginFromSSO(ApplicationDbContext _db, string Username, Guid ssoID, string Signature, string PreSignatureString)
        {
            if (!ts.isValidSignature(PreSignatureString, Signature))
            {
                throw new Exception("Signature not Valid!");
            }

            var user = um.GetUser(Username);
            
            if (user == null)
            {
                // create new user
                user.Email = Username;
                user.SsoId = ssoID;
                var newUser = um.CreateUser(user);
                _db.SaveChanges();
            }

            Session session = sm.CreateSession(_db, user);
            _db.SaveChanges();

            LoginManagerDTO response;
            response = new LoginManagerDTO
            {
                Token = session.Token
            };
            return response;
        }


    }
}
