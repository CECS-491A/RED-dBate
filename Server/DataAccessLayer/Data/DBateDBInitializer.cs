using KFC.Red.DataAccessLayer;
using KFC.Red.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.RED.DataAccessLayer.Data
{
    public class DBateDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            IList<User> defaultStandards = new List<User>();

            defaultStandards.Add(new User() { ID = 1, Username = "cf2080@gmail.com", Password = "qweerttsd", DateOfBirth = new DateTime(1996,12,15), City = "Long Beach", State = "CA", Country = "USA", Role = "Registered User", CollectionClaims = null });
            defaultStandards.Add(new User() { ID = 2, Username = "cf2090@gmail.com", Password = "qweerttsd", DateOfBirth = new DateTime(1996, 12, 15), City = "Long Beach", State = "CA", Country = "USA", Role = "Registered User", CollectionClaims = null });
            defaultStandards.Add(new User() { ID = 3, Username = "cf2095@gmail.com", Password = "qweerttsd", DateOfBirth = new DateTime(1996, 12, 15), City = "Long Beach", State = "CA", Country = "USA", Role = "Registered User", CollectionClaims = null });

            //context.Users.AddRange(defaultStandards);

            base.Seed(context);
        }
    }
}
