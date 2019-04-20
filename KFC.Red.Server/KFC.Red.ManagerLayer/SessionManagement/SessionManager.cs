using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.SessionService;
using KFC.Red.ServiceLayer.TokenService;
using KFC.Red.ServiceLayer.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Session CreateSession(ApplicationDbContext _db, User user)
        {
            var userResp = _uService.GetUser(_db, user.Email);
            if (userResp == null)
            {
                return null;
            }


            Session session = new Session();
            session.UId = user.ID;
            session.Token = _tService.GenerateToken();
            return _sService.CreateSession(_db, session);
        }

        public string DeleteSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                Session response = _sService.DeleteSession(_db, token);

                _db.SaveChanges();
                return response.Token;
            }
        }

        public Session GetSession(string token)
        {
            using (var _db = new ApplicationDbContext())
            {
                Session response = _sService.GetSession(_db, token);

                _db.SaveChanges();
                return response;
            }
        }
    }
}
