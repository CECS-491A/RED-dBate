using KFC.Red.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.Interfaces
{
    /// <summary>
    /// Reusable functions for Configurations
    /// </summary>
    public interface IConfigure
    {
        bool ConfigureName(User u1, User u2, string name);
        bool ConfigureRole(User u1, User u2, string role);
        bool ConfigurePassword(User u1, User u2, string password);
        bool ConfigureLocation(User u1, User u2, string city, string state, string country);
        bool ConfigureDOB(User u1, User u2, DateTime dob);
        bool ConfigureUsername(User u1, User u2, string uName);
    }
}
