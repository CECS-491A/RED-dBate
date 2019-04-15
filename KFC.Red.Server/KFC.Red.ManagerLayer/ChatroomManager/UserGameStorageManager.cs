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

        public List<string> GetGameUsers(int gid)
        {
            UserManager um = new UserManager();
            List<string> users = new List<string>();
            List<UserGameStorage> ugs = GetSessionUsers(gid);
            for (int i = 0; i < ugs.Capacity; i++)
            {
                UserGameStorage ug = ugs[i];
                User u = um.GetUser(ug.UId);
                users.Add(u.Email);
            }
            return users;
        }
    }
}
