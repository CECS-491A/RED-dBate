using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFC.Red.DataAccessLayer.Models
{
    public class Claim
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int ID { get; set; }
        public string ClaimName { get; set; }

        #region Constructors
        public Claim()
        {

        }

        public Claim(int id, string c)
        {
            ID = id;
            ClaimName = c;
        }
        #endregion
    }
}
