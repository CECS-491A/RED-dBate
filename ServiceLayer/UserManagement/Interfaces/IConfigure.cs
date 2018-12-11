using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IConfigure
    {
        bool ConfigureName(User u1, User u2, string name);
        bool ConfigureRole(User u1, User u2, string role);
        bool ConfigurePassword(User u1, User u2, string password);
        bool ConfigureLocation(User u1, User u2, Location loc);
        bool ConfigureDOB(User u1, User u2, DateOfBirth dob);
        bool ConfigureUsername(User u1, User u2, string uName);
    }
}
