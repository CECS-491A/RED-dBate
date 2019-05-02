using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.DTOs
{
    public class DeleteUserDTO
    {
        public string AppId { get; set; }
        public string Email { get; set; }
        public string SsoUserId { get; set; }
        public long Timestamp { get; set; }
        public string Signature { get; set; }

        public string PreSignatureString()
        {
            string acc = "";
            acc += "ssoUserId=" + SsoUserId + ";";
            acc += "email=" + Email + ";";
            acc += "timestamp=" + Timestamp + ";";
            return acc;
        }
    }
}
