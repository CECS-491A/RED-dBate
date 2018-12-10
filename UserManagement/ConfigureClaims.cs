using DataAccessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class ConfigureClaims
    {
        /// <summary>
        /// interface class that keeps track of data by having classes that can get repositories and saving it
        /// </summary>
        private IUnitOfWork _uow;

        /// <summary>
        /// IRepository class, containins method used to add,delete, configure accounts/info
        /// </summary>
        private IRepository<User> _User;

        /// <summary>
        /// Contructor for Class initiates uow(unit of work) and user repository
        /// </summary>
        /// <param name="uow">interface class that keeps track of data by having classes that can get repositories and saving it</param>
        public ConfigureClaims(IUnitOfWork uow)
        {
            _uow = uow;
            _User = _uow.GetRepository<User>();
        }

        /// <summary>
        /// Method used to add more claims to the users account
        /// </summary>
        /// <param name="u1">user performing operation</param>
        /// <param name="u2">user that is habing claims added</param>
        /// <param name="claim">claim that is being added</param>
        /// <returns>claimAdded = True or False</returns>
        public bool AddClaim(User u1, User u2, Claim claim)
        {
            bool claimAdded = false;

            if ((u1.Role == "System Admin" || u1.Role == "Admin") && u2.Role == "Registered User")
            {
                u2.CollectionClaims.Add(claim);
                _User.Update(u2);
                _uow.Save();
                claimAdded = true;
            }
            else if (u2.Role == "System Admin" && u2.Role == "Admin")
            {
                u2.CollectionClaims.Add(claim);
                _User.Update(u2);
                _uow.Save();
                claimAdded = true;
            }
            else
            {
                claimAdded = false;
                //throw new Exception("Didn't meet any of the requirements");
            }

            return claimAdded;
        }

        /// <summary>
        /// Method used to delete a claim from the users account
        /// </summary>
        /// <param name="u1">user performing operation</param>
        /// <param name="u2">user that is having claims deleted</param>
        /// <param name="claim">claim that is being delete</param>
        /// <returns>claimDeleted = True or False</returns>
        public bool DeletedClaim(User u1, User u2, Claim claim)
        {
            bool claimDeleted = false;

            if ((u1.Role == "System Admin" || u1.Role == "Admin") && u2.Role == "Registered User")
            {
                Console.WriteLine("1");
                DeleteSpecificClaim(u2, claim);
                _User.Update(u2);
                _uow.Save();
                claimDeleted = true;
            }
            else if (u2.Role == "System Admin" && u2.Role == "Admin")
            {
                Console.WriteLine("2");
                DeleteSpecificClaim(u2, claim);
                _User.Update(u2);
                _uow.Save();
                claimDeleted = true;
            }
            else
            {
                claimDeleted = false;
                //throw new Exception("Didn't meet any of the requirements");
            }

            return claimDeleted;
        }

        /// <summary>
        /// Method that deletes specific claim
        /// </summary>
        /// <param name="u">user u object</param>
        /// <param name="claim">claim to delete</param>
        private void DeleteSpecificClaim(User u, Claim claim)
        {
            var collectionClaims = u.CollectionClaims;

            foreach (Claim c in collectionClaims)
            {
                if (collectionClaims.Contains(claim))
                {
                    u.CollectionClaims.Remove(claim);
                }
            }
        }
    }
}
