using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.ChatRoom;
using System.Collections.Generic;
using System.Linq;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class UserGameStorageManager
    {
        private UserGameStorageService _UGSService;

        public UserGameStorageManager()
        {
            _UGSService = new UserGameStorageService();
        }

        public int CreateUGS(UserGameStorage ugs)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _UGSService.CreateUGS(_db, ugs);
                // will return null if ugs does not exist
                return _db.SaveChanges();
            }
        }

        //Delete one user stored in User Game Storage
        public int DeleteGameUser(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _UGSService.DeleteUGS(_db, id);
                // will return null if ugs does not exist
                return _db.SaveChanges();
            }
        }

        //Delete all users associated with gamesession token
        public int DeleteGameSessionUsers(string gamesessionToken)
        {
            GameSessionManager gameSessionManager = new GameSessionManager();
            using (var _db = new ApplicationDbContext())
            {
                var gameSession = gameSessionManager.GetGameSession(gamesessionToken);
                var listOfUGS = _db.UserGameStorages.Where(w => w.GId == gameSession.Id);
                
                for(int i = 0; i < listOfUGS.Count(); i++)
                {
                    var gameUser = listOfUGS.ToList().ElementAt(i);
                    var response = _UGSService.DeleteUGS(_db, gameUser.Id);
                }

                return _db.SaveChanges();
            }
        }

        public int UpdateUGS(UserGameStorage ugs)
        {
            using (var _db = new ApplicationDbContext())
            {
                var respone = _UGSService.UpdateUGS(_db, ugs);
                return _db.SaveChanges();
            }
        }

        public int GetGameId(int userId)
        {
            using (var _db = new ApplicationDbContext())
            {
                var ugs = _db.UserGameStorages
                    .Where(user => user.UId == userId)
                    .FirstOrDefault<UserGameStorage>();
                if (ugs == null)
                {
                    return 0;
                }
                return ugs.GId;
            }
        }


        private List<UserGameStorage> GetSessionUsers(int gid)
        {
            using (var _db = new ApplicationDbContext())
            {
                var ugs = _db.UserGameStorages
                    .Where(s => s.GId == gid)
                    .ToList();

                return ugs;
            }
        }

        public List<UserGameStorage> GetUserGameStorages(int gid)
        {
            return GetSessionUsers(gid);
        }

        public UserGameStorage GetUserGameStorage(int uid)
        {
            using(var _db = new ApplicationDbContext())
            {
                var ugs = _db.UserGameStorages
                    .Where(user => user.UId == uid)
                    .Single();
                return ugs;
            }
        }

        public List<string> GetGameUsernames(int gid)
        {
            UserManager uManager = new UserManager();
            List<string> usernameList = new List<string>();
            List<UserGameStorage> ugsList = GetSessionUsers(gid);
            for (int i = 0; i < ugsList.Capacity; i++)
            {
                UserGameStorage ugs = ugsList[i];
                User user = uManager.GetUser(ugs.UId);
                usernameList.Add(user.Email);
            }
            return usernameList;
        }

        public List<User> GetGameUsers(int gid)
        {
            UserManager uManager = new UserManager();
            List<UserGameStorage> ugsList = GetSessionUsers(gid);
            List<User> users = new List<User>();
            for(int i = 0; i < ugsList.Capacity; i++)
            {
                UserGameStorage ugs = ugsList[i];
                users.Add(uManager.GetUser(ugs.UId));
            }
            return users;
        }

    }
}
