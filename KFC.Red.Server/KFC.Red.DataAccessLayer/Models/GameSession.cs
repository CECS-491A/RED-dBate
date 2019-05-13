using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class GameSession
    {
        //BRD said b/w 18-35 minutes
        public static readonly int MINUTES_UNTIL_EXPIRATION = 50;

        [Key]
        [Column(Order = 0)]
        [Required]
        public int Id { get; set; }
        public string Token { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime DeleteTime { get; set; } = DateTime.Now.AddMinutes(MINUTES_UNTIL_EXPIRATION);

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public bool isSessionUsed { get; set; } = false;

        public int PlayerCount { get; set; } = 0;
    }
}
