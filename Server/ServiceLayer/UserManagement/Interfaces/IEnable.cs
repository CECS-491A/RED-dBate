using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserManagement.Interfaces
{
    /// <summary>
    /// Reusable functions for enabling for user management
    /// </summary>
    public interface IEnable
    {
        bool DisableAccount(User u1, User u2);
        bool EnableAccount(User u1, User u2);
    }
}
