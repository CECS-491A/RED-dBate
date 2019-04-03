using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public DateTime DeleteTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdateTime { get; set; } = DateTime.UtcNow;

        [ForeignKey("User")]
        public int UId { get; set; }
        public User User { get; set; }


    }
}
