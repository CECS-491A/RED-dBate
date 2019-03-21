using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer;
using KFC.Red.ServiceLayer.UserManagement;
using KFC.Red.ServiceLayer.UserManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ManagerLayer.UserManagement
{
    public class UserManagement
    {
        //private IPasswordService _passwordService;
        private IUserService _userService;

        public UserManagement()
        {
            _userService = new UserService();
        }

        private ApplicationDbContext CreateDbContext()
        {
            return new ApplicationDbContext();
        }

        public int DeleteUser(User user)
        {
            using (var _db = CreateDbContext())
            {
                var response = _userService.DeleteUser(_db, user.ID);
                // will return null if user does not exist
                return _db.SaveChanges();
            }
        }

        public int DeleteUser(int id)
        {
            using (var _db = CreateDbContext())
            {
                var response = _userService.DeleteUser(_db, id);
                return _db.SaveChanges();
            }
        }

        public User GetUser(int id)
        {
            using (var _db = CreateDbContext())
            {
                return _userService.GetUser(_db, id);
            }
        }

        public User GetUser(string email)
        {
            using (var _db = CreateDbContext())
            {
                return _userService.GetUser(_db, email);
            }
        }

        public int DisableUser(User user)
        {
            return ToggleUser(user, false);
        }

        public int EnableUser(User user)
        {
            return ToggleUser(user, true);
        }

        public int ToggleUser(User user, bool? enable)
        {
            using (var _db = CreateDbContext())
            {
                if (enable == null) enable = !user.IsAccountActivated;
                user.IsAccountActivated = !(bool)enable;
                var response = _userService.UpdateUser(_db, user);
                return _db.SaveChanges();
            }
        }

        public int UpdateUser(User user)
        {
            using (var _db = CreateDbContext())
            {
                var response = _userService.UpdateUser(_db, user);
                try
                {
                    return _db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    // catch error
                    // rollback changes
                    _db.Entry(response).CurrentValues.SetValues(_db.Entry(response).OriginalValues);
                    _db.Entry(response).State = System.Data.Entity.EntityState.Unchanged;
                    return 0;
                }
            }
        }

        public bool ExistingUser(string email)
        {
            using (var _db = CreateDbContext())
            {
                return _userService.ExistingUser(_db, email);
            }
        }

        /*
        public List<User> GetAllUsers()
        {
            using(var _db = CreateDbContext())
            {
                List<User> list = _db.Set<User>().ToList();
                return list;
            }
        }
        */
    }
}
