using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class Activation
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
        public Activation(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method used to disable account of a user
        /// </summary>
        /// <param name="u">user object cotaining information to delete it's account</param>
        public void DisableAccount(User u1, User u2)
        {
            try
            {
                if (u1.Role == "System Admin" || u1.Role == "Admin")
                {
                    u2.IsAccountActivated = false;
                    _User.Update(u2);
                    _uow.Save();
                }
            }
            catch (Exception ex)
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

    }
}
