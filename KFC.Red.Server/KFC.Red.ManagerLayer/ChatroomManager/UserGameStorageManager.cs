using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.ChatRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var response = _UGSService.CreateUGS(_db,ugs);
                // will return null if ugs does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteUGS(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _UGSService.DeleteUGS(_db,id);
                // will return null if ugs does not exist
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
