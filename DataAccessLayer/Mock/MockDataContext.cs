using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mock
{
    public class MockDataContext
    {
        public List<User> User
        {
            get
            {
                return new List<User>
                {
                    new User
                    {
                       ID = 1,
                       Name = "Bob",
                       Role = "Admin",
                       CollectionClaims = {"View","Update", "Delete", "Create"}
                    },
                    new User
                    {
                       ID = 2,
                       Name = "Bill",
                       Role = "System Admin",
                       CollectionClaims = {"View","Update", "Delete", "Create", "CreateAdmin"}
                    },
                    new User
                    {
                       ID = 3,
                       Name = "Aaron Burr",
                       Role = "Registered User",
                       CollectionClaims = {"View"}
                    }
                };
            }
        }
    }

}
