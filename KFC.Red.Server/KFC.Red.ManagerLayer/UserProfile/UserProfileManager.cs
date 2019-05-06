using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ManagerLayer.UserManagement;

namespace KFC.Red.ManagerLayer.UserProfile
{
    public class UserProfileManager
    {
        private User user;
        private UserManager userM;

        public UserProfileManager()
        {
            user = new User();
            userM = new UserManager();
        }

        public User GetUserInfo(int id)
        {
            return userM.GetUser(user.ID);
        }

        //public User GetUserInfo(string email)
        //{
        //    return userM.GetUser(user.Email);
        //}

        public string DisplayUserEmail(User u)
        {
            return u.Email;
        }

    }
}
