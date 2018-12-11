using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Claim> ClaimCollection { get; set; }

        #region Constructors
        public Client()
        {
            List<Claim> ClaimCollection = new List<Claim>();
        }

        public Client(int id, string n, List<Claim> claims)
        {
            ID = id;
            Name = n;
            ClaimCollection = claims;
        }
        #endregion
    }
}