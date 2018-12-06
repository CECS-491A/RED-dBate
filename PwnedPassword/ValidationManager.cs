using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PwnedPassword
{
    class ValidationManager
    {
        //private static string userAgent = "DBate";
        //private static string URL = "https://api.pwnedpasswords.com/range/";
        private static PasswordValidationService pvs = new PasswordValidationService();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<int> IsPasswordSafe(string password)
        {
            SHA1 sha = SHA1.Create();
            byte[] byteHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            string stringHash = "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byteHash.Length; i++)
            {
                sb.Append(byteHash[i].ToString("X2"));
            }
            stringHash = sb.ToString();

            string prefix = stringHash.Substring(0, 5);
            var checkPwned = await pvs.CheckPassword(prefix);

            string restOfHash = stringHash.Substring(5, stringHash.Length - 5);
            int statusNumber;
            //var hashExists = checkPwned.Contains(restOfHash);
            if (checkPwned.Contains(restOfHash))
            {
                int index = checkPwned.IndexOf(restOfHash);
                statusNumber = AcceptRejectPassword(index, checkPwned);
            }
            //means that password not in the database. Return 0
            else
            {
                statusNumber = 0;
            }
            return statusNumber;
        }

        public int AcceptRejectPassword(int index, string checkedHash)
        {
            Regex colon = new Regex(@":(\d+)");
            Match counter = colon.Match(checkedHash, index);

            int.TryParse(counter.Value.Substring(1), out int result);
            int statusNumber;
            //Password has been breached before, recommended change password.
            if (result > 0 && result < 11)
            {
                statusNumber = 1;
            }
            //Password breached more than 10 times, must be changed.
            else
            {
                statusNumber = 2;
            }

            return statusNumber;
        }

    }
}
