using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.RED.DataAccessLayer.DTOs
{
    public class DeleteUserFromSSO_DTO
    {
        public string AppId { get; set; }
        public string Email { get; set; }
        public string SsoUserId { get; set; }
        public string Signature { get; set; }
        public long Timestamp { get; set; }
    }
}
