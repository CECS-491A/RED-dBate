using KFC.Red.DataAccessLayer.Data;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.UserManagement.Interfaces
{
    public interface IUserService
    {
        User CreateUser(ApplicationDbContext _db, User user);
        User GetUser(ApplicationDbContext _db, string email);
        User GetUser(ApplicationDbContext _db, int Id);
        User DeleteUser(ApplicationDbContext _db, int Id);
        User UpdateUser(ApplicationDbContext _db, User user);
        bool ExistingUser(ApplicationDbContext _db, string email);
    }
}
