using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.SessionManagement;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.SSO_Services;
using System;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.SSO
{
    public class SSO_Manager
    {
        public Session LoginFromSSO(string email, Guid ssoID)
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

                return session;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAccountSSO(User user)
        {
            var SSO_API = new SSO_APIService();
            var deletedUser = await SSO_API.DeleteUserFromSSO(user);

            if (deletedUser.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}
