using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    /// <summary>
    /// Class that allows enables users depending on their role to control user access such as creating, deleting, updating accounts
    /// as well as configuring account information/rights
    /// </summary>
    public class UserManagement_Manager
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
        public UserManagement_Manager(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method that checks whether the collection of users contains duplicate usernames
        /// </summary>
        /// <param name="u">user u object</param>
        /// <returns>returns true or false</returns>
        public bool Duplication(User u)
        {
            IEnumerable<User> listUsers = _User.GetAll().AsEnumerable<User>();
            bool duplicate = true;

            // do a seperate method
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
        /// method that creates a user account for them to use
        /// </summary>
        /// <param name="u">User object that contains user information used to create account</param>
        public void CreateAccount(User u)
        {
            bool duplicate = Duplication(u);

            try
            {
                if(u.Role == "Registered User")
                {
                    if(u.Username != null && duplicate != false && u.Password != null && u.DOB != null && u.Location != null)
                    {
                        _User.Add(u);
                        _uow.Save();
                    }
                }
                else if(u.Role == "System Admin" || u.Role == "Admin")
                {
                    if(u.Username != null && u.DOB != null && u.Location != null){
                        _User.Add(u);
                        _uow.Save();
                    }
                }
                else
                {
                    throw new Exception("Failure Creating an account");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failure Creating User Account", ex);
            }
        }

        /// <summary>
        /// Method used to disable account of a user
        /// </summary>
        /// <param name="u">user object cotaining information to delete it's account</param>
        public void DisableAccount(User u1, User u2)
        {
            try
            {
                if(u1.Role == "System Admin" || u1.Role == "Admin")
                {
                    u2.IsAccountActivated = false;
                    _User.Update(u2);
                    _uow.Save();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Failure in Disabling Account", ex);
            }
        }

        /// <summary>
        /// Method that enables an account to be used
        /// </summary>
        /// <param name="u">user object containing information needed to enable the user account</param>
        public void EnableAccount(User u)
        {
            try
            {
                u.IsAccountActivated = true;
                _User.Update(u);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure in Enabling Account", ex);
            }
        }

        /// <summary>
        /// Method used to delete account of a user
        /// </summary>
        /// <param name="u">object containing user information used to delete account</param>
        public void DeleteAccount(User u)
        {
            try
            {
                _User.Delete(u);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure deleting User", ex);
            }
        }

        /// <summary>
        /// Method used to update name of users account
        /// </summary>
        /// <param name="u">user object containing info to configure</param>
        /// <param name="name">updated name</param>
        public void ConfigureName(User u, string name)
        {
            try
            {
                u.Name = name;
                _User.Update(u);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure Configuring name of user", ex);
            }
        }

        /// <summary>
        /// Method that updates role of the account
        /// </summary>
        /// <param name="u">object containing users information that can be updated</param>
        /// <param name="role">updated role of the user</param>
        public void ConfigureRole(User u, string role)
        {
            try
            {
                u.Role = role;
                _User.Update(u);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure Configuring role of user", ex);
            }
        }

        /// <summary>
        /// Method used to add more claims to the users account
        /// </summary>
        /// <param name="u">object containing information that can be configured</param>
        /// <param name="claim">claim to be added to the user</param>
        public void AddClaim(User u, string claim)
        {
            try
            {
                u.CollectionClaims.Add(claim);
                _User.Update(u);
                _uow.Save();
            }
            catch(Exception ex)
            {
                throw new Exception("Failure Adding new Claim to User", ex);
            }
        }

        /// <summary>
        /// Method used to delete a claim that a user has stored
        /// </summary>
        /// <param name="u">object containing the users information</param>
        /// <param name="claim">claim to be deleted from account</param>
        public void DeleteClaim(User u, string claim)
        {
            try
            {
                u.CollectionClaims.Remove(claim);
                _User.Update(u);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure Deleting Claim of User", ex);
            }
        }

        /// <summary>
        /// Method that configures claim of a user account
        /// </summary>
        /// <param name="u">object used containing user account information</param>
        /// <param name="neededClaim">claim that is going to be updated</param>
        /// <param name="updatedClaim">updated claim that the user wants</param>
        public void ConfigureClaim(User u, string neededClaim, string updatedClaim)
        {
            try
            {
                int index = u.CollectionClaims.BinarySearch(neededClaim);
                u.CollectionClaims.Insert(index, updatedClaim);
                _User.Update(u);
                _uow.Save();
            }
            catch(Exception ex)
            {
                throw new Exception("Failure Updating a Claim of a User", ex);
            }
        }

        //MORE METHODS HAVE TO BE ADDED IN PROGRESS.....
    }
}
