using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace KFC.RED.DataAccessLayer.Repositories
{
    public class UserGameStorageRepository
    {
        public UserGameStorage CreateNewUGS(ApplicationDbContext _db, UserGameStorage ugs)
        {
            _db.Entry(ugs).State = EntityState.Added;
            return ugs;
        }

        public UserGameStorage DeleteUGS(ApplicationDbContext _db, int Id)
        {
            var ugs = _db.UserGameStorages
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            if (ugs == null)
                return null;
            _db.Entry(ugs).State = EntityState.Deleted;
            return ugs;
        }

        public UserGameStorage UpdateUGS(ApplicationDbContext _db, UserGameStorage ugs)
        {
            _db.Entry(ugs).State = EntityState.Modified;
            return ugs;
        }

        public UserGameStorage GetUGS(ApplicationDbContext _db, int Id)
        {
            return _db.UserGameStorages.Find(Id);
        }

        public UserGameStorage GetGameUser(ApplicationDbContext _db, int id)
        {
            return _db.UserGameStorages.Find(id);
        }

        public bool ExistingUGS(ApplicationDbContext _db, int id)
        {
            var result = GetUGS(_db, id);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
