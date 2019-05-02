using System.ComponentModel.DataAnnotations;

namespace KFC.Red.DataAccessLayer.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string SSOUserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Timestamp { get; set; }
        [Required]
        public string Signature { get; set; }
    }
}
