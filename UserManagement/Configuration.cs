using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class Configuration
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
            catch (Exception ex)
            {
                throw new Exception("Failure Adding new Claim to User", ex);
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
            catch (Exception ex)
            {
                throw new Exception("Failure Updating a Claim of a User", ex);
            }
        }

        //MORE METHODS HAVE TO BE ADDED IN PROGRESS.....
    }
}
