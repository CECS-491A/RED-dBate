using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserManagement
{
    public class Creation
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
        public Creation(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method that checks whether the collection of users contains duplicate usernames
        /// </summary>
        /// <param name="u">user u object</param>
        /// <returns>returns true or false</returns>
        private bool Duplication(User u)
        {
            IEnumerable<User> listUsers = _User.GetAll().AsEnumerable<User>();
            bool duplicate = false;

            // do a seperate method
            foreach (User ur in listUsers)
            {
                if (ur.Username == u.Username)
                {
                    duplicate = true;
                }
            }
            return duplicate;
        }

        /// <summary>
        /// method that creates a user account for them to use
        /// </summary>
        /// <param name="u1">user object representing user performing the create function</param>
        /// <param name="u2">user account being created</param>
        /// <returns>accountCreated = True or False</returns>
        public bool CreateAccount(User u1, User u2)
        {
            bool duplicate = Duplication(u2);
            bool accountCreated = false;

            if ((u1.Role == "System Admin" || u1.Role == "Admin") && u2.Role == "Registered User")
            {
                if (duplicate == false && u2.Password != null && u2.DOB != null && u2.Location != null)
                {
                    _User.Add(u2);
                    _uow.Save();
                    accountCreated = true;
                }
                Console.WriteLine("hello1" + accountCreated);
            }
            else if (u1.Role == "System Admin" && u2.Role == "Admin")
            {
                if (u2.Username != null && u2.DOB != null && u2.Location != null)
                {
                    _User.Add(u2);
                    _uow.Save();
                    accountCreated = true;
                }
                Console.WriteLine("hello2");
            }
            else if (u1.Role == "Admin" && u2.Role == "Registered User")
            {
                if (u2.Username != null && duplicate == false && u2.Password != null && u2.DOB != null && u2.Location != null)
                {
                    _User.Add(u2);
                    _uow.Save();
                    accountCreated = true;
                }
                Console.WriteLine("hello3");
            }
            else
            {
                accountCreated = false;
                Console.WriteLine("hello4");
            }

            Console.WriteLine("hello5");

            return accountCreated;
            }
        }
    }
