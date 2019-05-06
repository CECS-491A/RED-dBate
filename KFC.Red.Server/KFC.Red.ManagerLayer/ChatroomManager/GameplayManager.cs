using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.ChatRoom;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class GameplayManager
    {
        private UserManager uManager;
        private UserGameStorageManager ugsManager;
        private GameplayService gameService;

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
            var gameId = ugsManager.GetGameId(user.ID);
            List<int> orders = new List<int>();

            if (string.IsNullOrEmpty(user.Role) && gameId > 0)
            {
                var sessionUsers = ugsManager.GetGameUsers(gameId)
                    .Where(sUser => string.IsNullOrEmpty(sUser.Role) == false)
                    .ToList();

                var teamNumber = gameService.AssignTeam(sessionUsers);
                if (teamNumber == 1)
                {
                    user.Role = "Team1";
                    uManager.UpdateUser(user);
                }
                else
                {
                    user.Role = "Team2";
                    uManager.UpdateUser(user);
                }

                var currentTeam = ugsManager.GetGameUsers(gameId)
                        .Where(tUser => String.Equals(tUser.Role, user.Role) && tUser.SsoId != user.SsoId) 
                        .ToList();

                var ugs = ugsManager.GetUserGameStorages(gameId);
                var orderNumber = gameService.AssignOrder(currentTeam, ugs);

                var currentUGS = ugsManager.GetUserGameStorage(user.ID);
                currentUGS.Order = orderNumber;

                return ugsManager.UpdateUGS(currentUGS);
            }
            else
            {
                return 0;
            }
        }

    }
}
