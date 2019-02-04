using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Authorization
{
    /// <summary>
    /// Interface that has reusable authorization methods/functions
    /// </summary>
    public interface IAuthorize
    {
        //Method that returns whether a user is authorized to access a right
        bool CheckAccess(Claim claim);
    }
}
