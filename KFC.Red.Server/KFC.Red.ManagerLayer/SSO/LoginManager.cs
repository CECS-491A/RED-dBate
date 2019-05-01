using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.UserManagement;
using System;

namespace KFC.Red.ManagerLayer.SSO
{
    public class LoginManager
    {
        public Session LoginFromSSO(string email, Guid ssoID, long timestamp, string signature)
        {
            try
            {
                UserManager um = new UserManager();

                var user = um.GetUser(ssoID);
                if (user == null)
                {
                    user = new User()
                    {
                        SsoId = ssoID,
                        Email = email
                    };

                    um.CreateUser(user);
                }

                SessionManager sessionManager = new SessionManager();
                Session session = sessionManager.CreateSession(user);
                return session;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
