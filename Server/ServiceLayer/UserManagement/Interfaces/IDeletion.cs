using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserManagement.Interfaces
{
    /// <summary>
    /// Reusable functions for deletion for user management
    /// </summary>
    public interface IDeletion
    {
        bool DeleteAccount(User u1, User u2);
    }
}
