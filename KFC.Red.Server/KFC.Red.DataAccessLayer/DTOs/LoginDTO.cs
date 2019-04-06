using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Signature { get; set; }
        public string SSOUId { get; set; }
        public string Timestamp { get; set; }
    }
}
