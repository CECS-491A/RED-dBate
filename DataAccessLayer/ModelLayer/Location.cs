using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Location
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        #region Constructor
        public Location()
        {

        }

        public Location(string c, string s, string country)
        {
            City = c;
            State = s;
            Country = country;
        }
        #endregion
    }
}