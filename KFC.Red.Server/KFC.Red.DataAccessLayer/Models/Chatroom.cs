using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.RED.DataAccessLayer.Models
{
    public class Chatroom
    {
        [Required]
        public int ChatroomID { get; set; }
        public int QuestionID { get; set; }
        
    }
}
