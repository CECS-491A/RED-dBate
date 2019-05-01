using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.ManagerLayer.UserManagement;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class GameplayManager
    {
        private UserManager uManager;
        private UserGameStorageManager ugsManager;

        public GameplayManager()
        {
            uManager = new UserManager();
            ugsManager = new UserGameStorageManager();
        }

        public int AssignHost(Guid ssoId)
        {
            var user = uManager.GetUser(ssoId);
            user.Role = "Host";
            return uManager.UpdateUser(user);            
        }

        public int AssignPlayer(Guid ssoId)
        {
            var user = uManager.GetUser(ssoId);
            if (string.IsNullOrEmpty(user.Role))
            {
                var sessionUsers = ugsManager.GetGameUsers(user.ID)
                    .Where(sUser => string.IsNullOrEmpty(sUser.Role) == false)
                    .ToList();
                int t1Count = 0, t2Count = 0;
                for (int i = 0; i < sessionUsers.Count(); i++)
                {
                    if(String.Equals(sessionUsers[i].Role, "Team1"))
                    {
                        t1Count++;
                    }
                    else if(String.Equals(sessionUsers[i].Role, "Team2"))
                    {
                        t2Count++;
                    }
                }
                if(t1Count <= t2Count)
                {
                    user.Role = "Team1";
                }
                else
                {
                    user.Role = "Team2";
                }
                return uManager.UpdateUser(user);
            }
            else
            {
                return 0;
            }
        }

    }
}
