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
    /// 
    /// </summary>
    public class UserManagement
    {
        /// <summary>
        /// 
        /// </summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// 
        /// </summary>
        private IRepository<User> _User;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public UserManagement(IUnitOfWork uow)
        {
            _uow = uow;

            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        public void CreateAccount(User u)
        {
            try
            {
                _User.Add(u);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure Creating User Account", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        public void DisableAccount(User u)
        {
            try
            {
                u.IsAccountActivated = false;
                _User.Update(u);
                _uow.Save();
            }
            catch(Exception ex)
            {
                throw new Exception("Failure in Disabling Account", ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="name"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="role"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="claim"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="claim"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="neededClaim"></param>
        /// <param name="updatedClaim"></param>
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
    }
}
