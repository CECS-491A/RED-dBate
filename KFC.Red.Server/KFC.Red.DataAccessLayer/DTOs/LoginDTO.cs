using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Signature { get; set; }
        [Required]
        public string SSOUId { get; set; }
        [Required]
        public string Timestamp { get; set; }

        public string PreSignatureString()
        {
            string acc = "";
            acc += "ssoUserId=" + SSOUId + ";";
            acc += "email=" + Email + ";";
            acc += "timestamp=" + Timestamp + ";";
            return acc;
        }

        public LoginDTO()
        {

        }

        public LoginDTO(string e, string sig, string id, string t)
        {
            Email = e;
            Signature = sig;
            SSOUId = id;
            Timestamp = t;
        }
    }
}
