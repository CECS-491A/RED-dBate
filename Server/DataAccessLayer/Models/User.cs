using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.DataAccessLayer.Models
{
    /// <summary>
    /// Model Class for User
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID of user, used for storage, organizing
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// username of user
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// password of user
        /// </summary>
        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        /// <summary>
        /// represents the role that the specific user has
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// list of claims/rights that a user has
        /// </summary>
        public List<Claim> CollectionClaims { get; set; }

        /// <summary>
        /// bool variable that knows whether account is activated (True/False)
        /// </summary>
        public bool IsAccountActivated { get; set; }

        public ICollection<Connection> Connections { get; set; }

        //public bool IsUserPlaying { get; set; }

        //CONSTRUCTORS NEED TO BE FIXED
        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public User()
        {
            CollectionClaims = new List<Claim>();

        }

        /// <summary>
        /// Consturctor for user class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="dob"></param>
        /// <param name="r"></param>
        /// <param name="loc"></param>
        /// <param name="c"></param>
        public User(int id, string n, string p, DateTime dob, string r, string cty, string s, string ctry, List<Claim> c)
        {
            ID = ID;
            Username = n;
            Password = p;
            DateOfBirth = dob;
            City = cty;
            State = s;
            Country = ctry;
            Role = r;
            CollectionClaims = c;
        }
        #endregion
    }
}