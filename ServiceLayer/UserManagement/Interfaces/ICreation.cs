using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserManagement.Interfaces
{
    public interface ICreation
    {
        bool CreateAccount(User u1, User u2);
    }
}
