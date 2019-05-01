using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.DataAccessLayer.Repositories;
using KFC.Red.ServiceLayer.UserManagement.Interfaces;

namespace KFC.Red.ServiceLayer.UserManagement
{
    public class UserService : IUserService
    {
        private UserManagementRepository _UserManagementRepo;

        public UserService()
        {
            _UserManagementRepo = new UserManagementRepository();
        }

        public User CreateUser(ApplicationDbContext _db, User user)
        {
            if (_UserManagementRepo.ExistingUser(_db, user.Username))
            {
                throw new ArgumentException("A user with that email address already exists");
            }
            return _UserManagementRepo.CreateNewUser(_db, user);
        }

        public User DeleteUser(ApplicationDbContext _db, int Id)
        {
            return _UserManagementRepo.DeleteUser(_db, Id);
        }

        public User GetUser(ApplicationDbContext _db, string email)
        {
            return _UserManagementRepo.GetUser(_db, email);
        }

        public User GetUser(ApplicationDbContext _db, int Id)
        {
            return _UserManagementRepo.GetUser(_db, Id);
        }

        public User GetUser(ApplicationDbContext _db, Guid ssoId)
        {
            return _UserManagementRepo.GetUser(_db,ssoId);
        }

        public User UpdateUser(ApplicationDbContext _db, User user)
        {
            return _UserManagementRepo.UpdateUser(_db, user);
        }

        public bool ExistingUser(ApplicationDbContext _db, string email)
        {
            return _UserManagementRepo.ExistingUser(_db, email);
        }
    }
}
