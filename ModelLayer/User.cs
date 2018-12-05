using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// Model Class for User
    /// </summary>
    public class User
    {
        /// <summary>
        /// ID of user, used for storage, organizing
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// username of user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password of user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// date of birth of user
        /// </summary>
        public string DOB { get; set; }

        /// <summary>
        /// location of user
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// represents the role that the specific user has
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// list of claims/rights that a user has
        /// </summary>
        public List<string> CollectionClaims { get; set; }

        /// <summary>
        /// bool variable that knows whether account is activated (True/False)
        /// </summary>
        public bool IsAccountActivated { get; set; }

        //CONSTRUCTORS NEED TO BE FIXED
        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public User()
        {
            CollectionClaims = new List<string>();

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
        public User(int id, string n, string p, string dob, string r, string loc, List<string> c)
        {
            ID = ID;
            Username = n;
            Password = p;
            DOB = dob;
            Location = loc;
            Role = r;
            CollectionClaims = c;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public User(int id, string n, string r, List<string> c)
        {
            ID = ID;
            Username = n;
            Role = r;
            CollectionClaims = c;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public User(string n, string r, List<string> c)
        {
            Name = n;
            Role = r;
            CollectionClaims = c;
        }

        /// <summary>
        /// Constructor for user class 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="c"></param>
        public User(string n, List<string> c)
        {
            Name = n;
            CollectionClaims = c;
        }
        #endregion
    }
}
