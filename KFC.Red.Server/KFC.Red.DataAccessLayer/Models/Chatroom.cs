using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class Chatroom
    {
        public int ChatroomID { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public Question Question { get; set; }

    }
}
