using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Repositories
{
    public class SessionRepository
    {
        public Session CreateSession(ApplicationDbContext _db, Session session)
        {
            _db.Entry(session).State = EntityState.Added;
            return session;
        }

        public Session UpdateSession(ApplicationDbContext _db, Session session)
        {
            session.UpdateTime = DateTime.UtcNow;
            session.DeleteTime = DateTime.UtcNow;
            _db.Entry(session).State = EntityState.Unchanged;
            return session;
        }

        public Session DeleteSession(ApplicationDbContext _db, int id)
        {
            var session = _db.Sessions
                .Where(s => s.Id == id)
                .FirstOrDefault();
            if (session == null)
                return null;
            _db.Entry(session).State = EntityState.Deleted;
            return session;
        }

        public Session DeleteSession(ApplicationDbContext _db, string token)
        {
            var session = _db.Sessions
                .Where(s => s.Token == token)
                .FirstOrDefault();
            if (session == null)
                return null;
            _db.Entry(session).State = EntityState.Deleted;
            return session;
        }

        public Session GetSession(ApplicationDbContext _db, int id)
        {
            var session = _db.Sessions
                .Where(s => s.Id == id)
                .FirstOrDefault();

            return session;
        }

        public Session GetSession(ApplicationDbContext _db, string token)
        {
            var session = _db.Sessions
                .Where(s => s.Token == token)
                .FirstOrDefault();

            return session;
        }
    }
}
