using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.SessionService
{
    public interface ISession
    {
        Session CreateSession(ApplicationDbContext _db, Session s);
        Session DeleteSession(ApplicationDbContext _db, int id);
        Session DeleteSession(ApplicationDbContext _db, string token);
        Session UpdateSession(ApplicationDbContext _db, Session s);
        Session GetSession(ApplicationDbContext _db, string token);
        Session GetSession(ApplicationDbContext _db, int id);
    }
}
