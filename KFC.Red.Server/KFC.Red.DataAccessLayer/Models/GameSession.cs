using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class GameSession
    {
        //BRD said b/w 18-35 minutes
        public static readonly int MINUTES_UNTIL_EXPIRATION = 35;

        public int Id { get; set; }
        public string Token { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public DateTime DeleteTime { get; set; } = DateTime.UtcNow.AddMinutes(MINUTES_UNTIL_EXPIRATION);

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
