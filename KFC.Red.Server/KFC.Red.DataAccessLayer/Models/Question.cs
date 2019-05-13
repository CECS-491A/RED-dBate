using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    public class Question
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int QuestionID { get; set; }
        public string QuestionString{ get; set; }
    }

}
