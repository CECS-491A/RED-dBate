using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.SessionService;
using KFC.Red.ServiceLayer.Token;
using KFC.Red.ServiceLayer.UserManagement;
using System;

namespace KFC.Red.ManagerLayer.SessionManagement
{
    public class SessionManager
    {
        private UserService _uService;
        private TokenService _tService;
        private SessionServ _sService;

        public SessionManager()
        {
            _uService = new UserService();
            _tService = new TokenService();
            _sService = new SessionServ();
        }

        public Session CreateSession(User user)
        {
            using (var _db = new ApplicationDbContext())
            {
                Session session = new Session
                {
                    UId = user.ID,
                    Token = _tService.GenerateToken()
                };

                var createdSession = _sService.CreateSession(_db, session);
                _db.SaveChanges();
                return createdSession;
            }
        }

        public int CreateSession(Session session)
        {
            using (var _db = new ApplicationDbContext())
            {
                var resp = _sService.CreateSession(_db, session);
                return _db.SaveChanges();
            }
        }

        public int DeleteSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                Session response = _sService.DeleteSession(_db, token);

                var resp = _db.SaveChanges();
                return resp;
            }
        }
 
        //Used to delete all sessions of users, Mostly used to delete from sso feature
        public int DeleteSessions(Guid userID)
        {
            using (var _db = new ApplicationDbContext())
            {
                var sessions = _sService.GetSessions(_db, userID);
                _db.Sessions.RemoveRange(sessions);
                var resp = _db.SaveChanges();
                return resp;
            }
        }

        public Session GetSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                Session response = _sService.GetSession(_db, token);

                return response;
            }
        }
    }
}
