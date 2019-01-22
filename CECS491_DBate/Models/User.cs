using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CECS491_DBate.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        public string Question1 { get; set; }
        [Required]
        public string Answer1 { get; set; }

        [Required]
        public string Question2 { get; set; }
        [Required]
        public string Answer2 { get; set; }

        [Required]
        public string Question3 { get; set; }
        [Required]
        public string Answer3 { get; set; }
        public bool IsAccountActivated { get; set; }

        //Foreign Key
        public int ClaimID { get; set; }
        public int RoleID { get; set; }
    }
}