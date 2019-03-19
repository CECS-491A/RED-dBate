using KFC.Red.DataAccessLayer;
using KFC.Red.DataAccessLayer.Models;
using KFC.Red.ServiceLayer.Constants;
using KFC.Red.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.UserManagement
{
    public class Configuration : Roles, IConfigure
    {
        /// <summary>
        /// interface class that keeps track of data by having classes that can get repositories and saving it
        /// </summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// IRepository class, containins method used to add,delete, configure accounts/info
        /// </summary>
        private IRepository<User> _User;

        /// <summary>
        /// Contructor for Class initiates uow(unit of work) and user repository
        /// </summary>
        /// <param name="uow">interface class that keeps track of data by having classes that can get repositories and saving it</param>
        public Configuration(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method used to update name of user account and return whether it was completed or not
        /// </summary>
        /// <param name="u1">User performing function</param>
        /// <param name="u2">user where name is being updated</param>
        /// <param name="name">updated name</param>
        /// <returns>true or false of nameConfigured</returns>
        public bool ConfigureName(User u1, User u2, string name)
        {
            bool nameConfigured = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.Name = name;
                _User.Update(u2);
                _uow.Save();
                nameConfigured = true;
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.Name = name;
                _User.Update(u2);
                _uow.Save();
                nameConfigured = true;
            }
            else
            {
                Console.WriteLine("Error: Configuting name Failed");
                nameConfigured = false;
            }

            return nameConfigured;
        }

        /// <summary>
        /// Method used to update role of user account and return whether it was completed or not
        /// </summary>
        /// <param name="u1">User performing function</param>
        /// <param name="u2">user where role is being updated</param>
        /// <param name="role">updated role</param>
        /// <returns>true or false of roleConfigured</returns>
        public bool ConfigureRole(User u1, User u2, string role)
        {
            bool roleConfigured = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.Role = role;
                _User.Update(u2);
                _uow.Save();
                roleConfigured = true;
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.Role = role;
                _User.Update(u2);
                _uow.Save();
                roleConfigured = true;
            }
            else
            {
                Console.WriteLine("Error: Configuting role Failed");
                roleConfigured = false;
            }

            return roleConfigured;
        }

        /// <summary>
        /// Method used to update password of user account and return whether it was completed or not
        /// </summary>
        /// <param name="u1">User performing function</param>
        /// <param name="u2">user where password is being updated</param>
        /// <param name="password">updated password</param>
        /// <returns>true or false of passwordConfigured</returns>
        public bool ConfigurePassword(User u1, User u2, string password)
        {
            bool passwordConfigured = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.Password = password;
                _User.Update(u2);
                _uow.Save();
                passwordConfigured = true;
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.Password = password;
                _User.Update(u2);
                _uow.Save();
                passwordConfigured = true;
            }
            else
            {
                Console.WriteLine("Error: Configuting password Failed");
                passwordConfigured = false;
            }

            return passwordConfigured;
        }

        /// <summary>
        /// Method used to update location of user account and return whether it was completed or not
        /// </summary>
        /// <param name="u1">User performing function</param>
        /// <param name="u2">user where location is being updated</param>
        /// <param name="loc">updated loc</param>
        /// <returns>true or false of locConfigured</returns>
        public bool ConfigureLocation(User u1, User u2, string city, string state, string country)
        {
            bool locConfigured = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.City = city;
                u2.State = state;
                u2.Country = country;
                _User.Update(u2);
                _uow.Save();
                locConfigured = true;
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.City = city;
                u2.State = state;
                u2.Country = country;
                _User.Update(u2);
                _uow.Save();
                locConfigured = true;
            }
            else
            {
                Console.WriteLine("Error: Configuting location Failed");
                locConfigured = false;
            }

            return locConfigured;
        }

        /// <summary>
        /// Method used to update dob of user account and return whether it was completed or not
        /// </summary>
        /// <param name="u1">User performing function</param>
        /// <param name="u2">user where dob is being updated</param>
        /// <param name="dob">updated dob</param>
        /// <returns>true or false of dobConfigured</returns>
        public bool ConfigureDOB(User u1, User u2, DateTime dob)
        {
            bool dobConfigured = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER)
            {
                u2.DateOfBirth = dob;
                _User.Update(u2);
                _uow.Save();
                dobConfigured = true;
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.DateOfBirth = dob;
                _User.Update(u2);
                _uow.Save();
                dobConfigured = true;
            }
            else
            {
                Console.WriteLine("Error: Configuting date of birth Failed");
                dobConfigured = false;
            }

            return dobConfigured;
        }

        /// <summary>
        /// Method that checks whether the collection of users contains duplicate usernames
        /// </summary>
        /// <param name="u">user u object</param>
        /// <returns>returns true or false</returns>
        private bool Duplication(User u)
        {
            IEnumerable<User> listUsers = _User.GetAll().AsEnumerable<User>();
            bool duplicate = true;

            foreach (User ur in listUsers)
            {
                if (ur.Username == u.Username)
                {
                    duplicate = false;
                }
            }
            return duplicate;
        }

        /// <summary>
        /// Method used to update username of user account and return whether it was completed or not
        /// </summary>
        /// <param name="u1">User performing function</param>
        /// <param name="u2">user where username is being updated</param>
        /// <param name="uName">updated username</param>
        /// <returns>true or false of uNameConfigured</returns>
        public bool ConfigureUsername(User u1, User u2, string uName)
        {
            bool duplicate = Duplication(u2);
            bool uNameConfigured = false;

            if ((u1.Role == SYS_ADMIN || u1.Role == ADMIN) && u2.Role == REG_USER && duplicate == false)
            {
                u2.Username = uName;
                _User.Update(u2);
                _uow.Save();
                uNameConfigured = true;
            }
            else if (u1.Role == SYS_ADMIN && u2.Role == ADMIN)
            {
                u2.Username = uName;
                _User.Update(u2);
                _uow.Save();
                uNameConfigured = true;
            }
            else
            {
                Console.WriteLine("Error: Configuting username Failed");
                uNameConfigured = false;
            }

            return uNameConfigured;
        }
    }
}