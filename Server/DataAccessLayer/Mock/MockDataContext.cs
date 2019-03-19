using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace KFC.Red.DataAccessLayer.Mock
{
    /// <summary>
    /// Class used to perform a Mock DataContext and also to store data of a User Object
    /// </summary>
    public class MockDataContext
    {
        /// <summary>
        /// Mock DataContext used to store/edit user object data stored in a List of User objects
        /// </summary>
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
                       Username = "Bob2080",
                       City = "Long Beach",
                       State = "CA",
                       Country = "USA",
                       Password = "Admin",
                       DateOfBirth = new DateTime(1993,12,15),
                       CollectionClaims = new List<Claim>{Claim[0], Claim[1], Claim[2], Claim[3]},
                       IsAccountActivated = true
                    },
                    new User
                    {
                       ID = 2,
                       Name = "Bill",
                       Role = "System Admin",
                       Username = "Bill2080",
                       City = "Long Beach",
                       State = "CA",
                       Country = "USA",
                       Password = "SystemAdmin",
                       DateOfBirth = new DateTime(1993,12,15),
                       CollectionClaims = Claim,
                       IsAccountActivated = true

                    },
                    new User
                    {
                       ID = 3,
                       Name = "Aaron Burr",
                       Role = "Registered User",
                       Username = "VicePresident",
                       City = "Long Beach",
                       State = "CA",
                       Country = "USA",
                       Password = "User1",
                       DateOfBirth = new DateTime(1993,12,15),
                       CollectionClaims = new List<Claim>{Claim[0]},
                       IsAccountActivated = true
                    }
                };
            }
        }

        public List<Claim> Claim
        {
            get
            {
                return new List<Claim>
                {
                    new Claim
                    {
                        ID = 1,
                        ClaimName  = "View"
                    },
                    new Claim
                    {
                        ID = 2,
                        ClaimName  = "Create"
                    },
                    new Claim
                    {
                        ID = 3,
                        ClaimName  = "Update"
                    },
                    new Claim
                    {
                        ID = 4,
                        ClaimName  = "Delete"
                    },
                    new Claim
                    {
                        ID = 5,
                        ClaimName  = "ViewDocument"
                    },
                    new Claim
                    {
                        ID = 6,
                        ClaimName  = "CreateAdmin"
                    }
                };
            }
        }

/*        public List<Client> Client
        {
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ID = 1,
                        Name = "IT",
                        ClaimCollection = Claim
                    }
                };
            }
        }
        */
    }
}
