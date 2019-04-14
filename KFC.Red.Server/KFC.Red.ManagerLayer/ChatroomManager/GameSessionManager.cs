using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.UserManagement;
using KFC.Red.ServiceLayer.ChatRoom;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.ChatroomManager
{
    public class GameSessionManager
    {
        private ChatStorage _ChatStore;
        private HubService _HubService;
        private GameSessionService _GSessionService;

        public GameSessionManager()
        {
            _ChatStore = new ChatStorage();
            _HubService = new HubService();
            _GSessionService = new GameSessionService();
        }

        public GameSessionManager(ChatStorage chatStore)
        {
            _ChatStore = chatStore;
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
            for(int i = 0; i < ugs.Capacity; i++)
            {
                UserGameStorage ug = ugs[i];
                User u = um.GetUser(ug.UId);
                users.Add(u.Email);
            }
            return users;
        }

        public int DeleteGameSession(GameSession gamesession)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _GSessionService.DeleteGameSession(_db, gamesession.Id);
                // will return null if gamesession does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteGameSession(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                var response = _GSessionService.DeleteGameSession(_db, id);
                return _db.SaveChanges();
            }
        }

        public GameSession GetGameSession(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.GetGameSession(_db, id);
            }
        }

        public GameSession GetGameSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.GetGameSession(_db,token);
            }
        }

        public bool ExistingGameSession(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.ExistingGameSession(_db, id);
            }
        }

        public bool ExistingGameSession(GameSession gs)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _GSessionService.ExistingGameSession(_db, gs);
            }
        }
    }
}
