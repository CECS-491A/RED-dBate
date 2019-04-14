using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.DataAccessLayer.Repositories;

namespace KFC.Red.ServiceLayer.SessionService
{
    public class SessionServ : ISession
    {
        private SessionRepository _SessionRepo;

        public SessionServ()
        {
            _SessionRepo = new SessionRepository();
        }

        public Session CreateSession(ApplicationDbContext _db, Session s)
        {
            return _SessionRepo.CreateSession(_db, s);
        }

        public Session DeleteSession(ApplicationDbContext _db, int id)
        {
            return _SessionRepo.DeleteSession(_db, id);
        }

        public Session DeleteSession(ApplicationDbContext _db, string token)
        {
            return _SessionRepo.DeleteSession(_db, token);
        }

        public Session GetSession(ApplicationDbContext _db, string token)
        {
            return _SessionRepo.GetSession(_db, token);
        }

        public Session GetSession(ApplicationDbContext _db, int id)
        {
            return _SessionRepo.GetSession(_db, id);
        }

        public Session UpdateSession(ApplicationDbContext _db, Session s)
        {
            return _SessionRepo.UpdateSession(_db, s);
        }
    }
}
