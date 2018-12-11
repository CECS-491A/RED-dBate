using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DateOfBirth
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        #region Constructor
        public DateOfBirth()
        {

        }

        public DateOfBirth(string d, string m, string y)
        {
            Day = d;
            Month = m;
            Year = y;
        }
        #endregion

    }
}

