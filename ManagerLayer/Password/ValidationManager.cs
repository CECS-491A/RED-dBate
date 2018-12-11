using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PwnedPassword
{
    public class ValidationManager
    {
        private static PasswordValidationService pvs = new PasswordValidationService();

        /// <summary>
        /// Checks whether a passed in password has been pwned previously.
        /// Determines if the password is safe (never been pwned),
        /// at risk (pwned 1-10 times), or unnacceptable(pwned > 10 times). 
        /// </summary>
        /// <param name="password">A password</param>
        /// <returns>PasswordStatus which conatins a number and message that determines is security risk. 
        /// 0 - no risk. 1 - small risk/recommend change password. 2 - risky/password not accepted 
        /// -1 - an error occurred in the http request </returns>
        public async Task<PasswordStatus> IsPasswordSafe(string password)
        {
            //Uses sha1 hash function to create hash of the password in bytes
            SHA1 sha = SHA1.Create();
            byte[] byteHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                        
            string stringHash = "";
            StringBuilder sb = new StringBuilder();

            //Formats bytes into uppercase hexadecimal characters and appends to stringbuilder
            for (int i = 0; i < byteHash.Length; i++)
            {
                sb.Append(byteHash[i].ToString("X2"));
            }
            stringHash = sb.ToString(); //Converts stringbuilder into string

            //Gets the first five characters of the hashed password (prefix) 
            string prefix = stringHash.Substring(0, 5);
            //Calls FindPassword to see all pwned passwords that have the same prefix
            //checkPwned is Task<String>
            var checkPwned = await pvs.FindPassword(prefix);
            
            //When an error occurs and checkPwned equals null, will return a -1 and message.
            if (string.IsNullOrEmpty(checkPwned))
            {
                PasswordStatus statusNull = new PasswordStatus(-1, "An ERROR has occurred while checking password security.");
                return statusNull;
            }

            //restOfHash is part of password hash that is not the prefix
            string restOfHash = stringHash.Substring(5, stringHash.Length - 5); 
            int statusNumber; //a number that will be used to determine the security of the password
            
            //If statement runs if restOfHash exists in the string
            if (checkPwned.Contains(restOfHash))
            {
                //Gets index in string where restOfHash starts
                int index = checkPwned.IndexOf(restOfHash); 
                //Gets an int that represents status of password. If this code ran, means that the password has been pwned.
                statusNumber = StatusOfPassword(index, checkPwned); 
            }
            //Otherwise, means that the password is not in the database. Return 0
            else
            {
                //0 means password has not been pwned previously.
                statusNumber = 0; 
            }
            //Gets a status message that goes along with the status number
            String statusMessage = StatusMessages(statusNumber);
            //Status number and message are stored in PasswordStatus object
            PasswordStatus status = new PasswordStatus(statusNumber,statusMessage);
            //Returns object
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="checkedHash"></param>
        /// <returns>Status Number</returns>
        public int StatusOfPassword(int index, string checkedHash)
        {
            //Represents a colon followed by 1 or more digits
            Regex colon = new Regex(@":(\d+)"); 
            // will search string for first occurence of given expression, starting from index 
            Match counter = colon.Match(checkedHash, index); 
            //Number of times password has been pwned is parsed.
            int.TryParse(counter.Value.Substring(1), out int result);

            int statusNumber;
            //Password has been breached a few times(1-10) before, recommend change password.
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

        /// <summary>
        /// Associates status number with a given status message.
        /// </summary>
        /// <param name="statusNumber"></param>
        /// <returns>Status message.</returns>
        public String StatusMessages(int statusNumber)
        {
            if(statusNumber == 0)
            {
                return "Password is safe to use!";
            }
            else if(statusNumber == 1)
            {
                return "Password has been breached a few times before! We recommend you change your password!";
            }
            else
            {
                return "Password is unsafe! Use a different password!";
            }
        }
    }
}
