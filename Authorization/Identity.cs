using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public class Identity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> CollectionClaims { get; set; }

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Identity()
        {
            CollectionClaims = new List<string>();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public Identity(int id, string n, string r, List<string> c)
        {
            ID = ID;
            Name = n;
            Role = r;
            CollectionClaims = c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        public Identity(string n, string r, List<string> c)
        {
            Name = n;
            Role = r;
            CollectionClaims = c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="c"></param>
        public Identity(string n, List<string> c)
        {
            Name = n;
            CollectionClaims = c;
        }
        #endregion
    }
}
