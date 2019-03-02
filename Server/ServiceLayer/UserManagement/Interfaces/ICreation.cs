using KFC.Red.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.UserManagement.Interfaces
{
    /// <summary>
    /// Reusable functions for Creation for user management
    /// </summary>
    public interface ICreation
    {
        bool CreateAccount(User u1, User u2);
    }
}
