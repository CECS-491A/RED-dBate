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
    public class UserManagementRepository
    {
        public User CreateNewUser(ApplicationDbContext _db, User user)
        {
            _db.Entry(user).State = EntityState.Added;
            return user;
        }

        public User DeleteUser(ApplicationDbContext _db, int Id)
        {
            var user = _db.Users
                .Where(c => c.ID == Id)
                .FirstOrDefault<User>();
            if (user == null)
                return null;
            _db.Entry(user).State = EntityState.Deleted;
            return user;
        }

        public User GetUser(ApplicationDbContext _db, string email)
        {
            var user = _db.Users
                .Where(c => c.Username == email)
                .FirstOrDefault<User>();
            return user;
        }

        public User GetUser(ApplicationDbContext _db, int Id)
        {
            return _db.Users.Find(Id);
        }

        
        public User GetUser(ApplicationDbContext _db, Guid SSOId)
        {
            var user = _db.Users.Where(c => c.SsoId == SSOId)
                .FirstOrDefault<User>();
            return user;
        }
        
        public User UpdateUser(ApplicationDbContext _db, User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            return user;
        }

        public bool ExistingUser(ApplicationDbContext _db, User user)
        {
            var result = GetUser(_db, user.Username);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistingUser(ApplicationDbContext _db, string email)
        {
            var result = GetUser(_db, email);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
