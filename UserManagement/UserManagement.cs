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
        /// <param name="id"></param>
        public void DeleteAccountbyId(int id)
        {
            try
            {
                User model = _User.GetAll().Where(s => s.ID == id).SingleOrDefault();
                _User.Delete(model);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure deleting User", ex);
            }
        }

        public void ConfigureName(User u, string name)
        {
            u.Name = name;
            _User.Update(u);
            _uow.Save();
        }

        public void ConfigureRole(User u, string role)
        {
            u.Role = role;
            _User.Update(u);
            _uow.Save();
        }

        //CLAIM MANAGEMENT HAS TO BE DONE
        public void DeleteClaim(User u, string claim)
        {
            //_User.Delete();
            _uow.Save();
        }
    }
}
