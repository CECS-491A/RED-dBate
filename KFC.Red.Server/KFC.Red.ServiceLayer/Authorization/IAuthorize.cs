
using KFC.Red.DataAccessLayer.Models;

namespace KFC.Red.ServiceLayer.Authorization
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
