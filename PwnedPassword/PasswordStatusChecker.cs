using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PwnedPassword
{
    class PasswordStatusChecker
    {
        public PasswordStatusChecker()
        {
            
        }

        /// <summary>
        /// Gets the status of the password. Gets both a status number and a status message.
        /// </summary>
        /// <param name="checkPwned"></param>
        /// <param name="restOfHash"></param>
        /// <returns>A PasswordStatus object containg the status number and message.</returns>
        public PasswordStatus StatusOfPassword(string checkPwned, string restOfHash)
        {
            int statusNumber;
            //There was an error so checkPwned is empty.
            if (string.IsNullOrEmpty(checkPwned))
            {   
                statusNumber = -1;
            }
            //Rest of the hashed password exists in checkpwned
            else if(checkPwned.Contains(restOfHash))
            { 
                int index = checkPwned.IndexOf(restOfHash);
                //Represents a colon followed by 1 or more digits
                Regex colon = new Regex(@":(\d+)");
                // will search string for first occurence of given expression, starting from index 
                Match counter = colon.Match(checkPwned, index);
                //Number of times password has been pwned is parsed.
                int.TryParse(counter.Value.Substring(1), out int result);
                
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
            }
            //Password has not been pwned previously.
            else
            {
                statusNumber = 0;
            }
            String statusMessage = StatusMessages(statusNumber);
            PasswordStatus status = new PasswordStatus(statusNumber, statusMessage);

            return status;
        }

        /// <summary>
        /// Associates status number with a given status message.
        /// </summary>
        /// <param name="statusNumber"></param>
        /// <returns>Status message.</returns>
        public String StatusMessages(int statusNumber)
        {
            if(statusNumber == -1)
            {
                return "An ERROR has occurred while checking password security.";
            }
            else if (statusNumber == 0)
            {
                return "Password is safe to use!";
            }
            else if (statusNumber == 1)
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
