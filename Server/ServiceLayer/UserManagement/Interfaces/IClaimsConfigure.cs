using KFC.Red.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.Interfaces
{
    /// <summary>
    /// Reusable functions for Configuration for claims
    /// </summary>
    public interface IClaimsConfigure
    {
        bool AddClaim(User u1, User u2, Claim c);
        bool DeletedClaim(User u1, User u2, Claim c);
    }
}
