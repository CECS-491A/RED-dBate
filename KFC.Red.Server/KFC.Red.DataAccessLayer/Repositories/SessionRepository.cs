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
        public Session CreateSession(ApplicationDbContext _db, Session session, int uId)
        {
            session.Id = uId;
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
    }
}
