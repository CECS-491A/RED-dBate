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
        public HubService _HubService;
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
