using KFC.Red.DataAccessLayer.DTOs;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.Logging;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.UserManagement;
using System;

namespace KFC.Red.ManagerLayer.SSO
{
    public class SSO_Manager
    {
        private int successLogin;
        private int failLogin;
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
                var session = sessionManager.CreateSession(user);
                successLogin++;

                return session;
            }
            catch (Exception ex)
            {
                
                var lm = new LoggingManager<ErrorLogDTO>();
                lm.CreateErrorLog(ex, "");
                failLogin++;
                return null;
            }
        }

        public void Logout()
        {

        }
    }
}
