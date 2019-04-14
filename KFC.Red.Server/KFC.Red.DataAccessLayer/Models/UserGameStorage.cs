using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class UserGameStorage
    {
        public int Id { get; set; }

        [ForeignKey("GameSession")]
        public int GId { get; set; }
        public GameSession GameSession { get; set; }

        [ForeignKey("User")]
        public int UId { get; set; }
        public User User { get; set; }
    }
}
