using ServiceLayer.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Password
{
    public class ValidationManager
    {
        private static PasswordValidationService pvs = new PasswordValidationService();
        private static HashFunction sHash = new HashFunction();
        private static PasswordStatusChecker checkStatus = new PasswordStatusChecker();

        /// <summary>
        /// Checks whether a passed in password has been pwned previously.
        /// Determines if the password is safe (never been pwned),
        /// at risk (pwned 1-10 times), or unnacceptable(pwned > 10 times). 
        /// </summary>
        /// <param name="password">A password</param>
        /// <returns>PasswordStatus which conatins a number and message that determines the security risk. 
        /// 0 - no risk. 1 - small risk/recommend change password. 2 - risky/password not accepted 
        /// -1 - an error occurred in the http request </returns>
        public async Task<PasswordStatus> IsPasswordSafe(string password)
        {
            if (password.Length < 12)
            {
                PasswordStatus status = new PasswordStatus(-2, "That's not a valid password!");
                return status;
            }
            else {
                //Password converted to bytes and hashed.
                string stringHash = sHash.StringHash(password);
                //Gets the first five characters of the hashed password (prefix) 
                string prefix = stringHash.Substring(0, 5);
                //Calls FindPassword to see all pwned passwords that have the same prefix
                //checkPwned is Task<String>
                var checkPwned = await pvs.FindPassword(prefix);
                //restOfHash is part of password hash that is not the prefix
                string restOfHash = stringHash.Substring(5, stringHash.Length - 5);

                //Check if password has been pwned and if its usable. Get object with int representing status & a message.
                //Status number and message are stored in PasswordStatus object
                PasswordStatus status = checkStatus.StatusOfPassword(checkPwned, restOfHash);
                return status;
            }
        }
        
    }
}
