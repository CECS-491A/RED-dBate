using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class UserService
    {
        private IUnitOfWork _uow;

        private IRepository<User> _User;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;

            _User = _uow.GetRepository<User>();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _User.GetAll();
        }

        public User GetUserByID(int id)
        {
            try
            {
                return _User.GetAll().Where(s => s.ID == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure getting User", ex);
            }
        }

        public void DeleteUserByID(int id)
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
    }

}
