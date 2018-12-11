using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwnedPassword
{   
    /// <summary>
    /// Holds the pwned status and status message of the password.
    /// </summary>
    public class PasswordStatus
    {
        //An integer representing the status of the password's pwned status
        public int Status { get; set; }
        //A string containing the message that accompanies the status.
        public string Message { get; set; }

        public PasswordStatus(int statusNumber, String statusMessage)
        {
            Status = statusNumber;
            Message = statusMessage;
        }
    }
}
