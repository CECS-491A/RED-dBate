using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Claim
    {
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

