using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    /// <summary>
    /// Class that contains claims that specific role might have
    /// </summary>
    public class ConstantRoleClaims
    {

        /// <summary>
        /// Method that returns claims that a regular system admin has
        /// </summary>
        /// <returns>list of string claims</returns>
        public List<string> GetSystemAdminClaims()
        {
            List<string> sysAdminClaims = new List<string>();
            sysAdminClaims = GetAdminClaims();
            sysAdminClaims.Add("Create Admin Account");
            sysAdminClaims.Add("Update Admin Account");
            sysAdminClaims.Add("Disable Admin Account");
            sysAdminClaims.Add("Enable Admin Account");
            return sysAdminClaims;
        }

        /// <summary>
        /// Method that returns claims that an admin user would have normally
        /// </summary>
        /// <returns>list of string adminclaims</returns>
        public List<string> GetAdminClaims()
        {
            List<string> adminClaims = new List<string>();
            adminClaims = GetRegUserClaims();
            adminClaims.Add("Create Regular User Account");
            adminClaims.Add("Update Regular User Account");
            adminClaims.Add("Disable Regular User Account");
            adminClaims.Add("Enable Regular User Account");
            return adminClaims;
        }

        /// <summary>
        /// Method that returns claims that a regular user would have normally
        /// </summary>
        /// <returns>list of string reguser claims</returns>
        public List<string> GetRegUserClaims()
        {
            List<string> regUserClaims = new List<string>();
            regUserClaims.Add("View Documents");
            regUserClaims.Add("View Pages");
            regUserClaims.Add("Update Password");

            return regUserClaims;
        }
    }
}
