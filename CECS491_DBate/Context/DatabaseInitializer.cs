using CECS491_DBate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CECS491_DBate.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            //context.Countries.Add(country);
            User user = new User
            {
                Id = 1,
                Email = "csulb2019@hotmail.com",
                Password = "theBest$",
                DOB = DateTime.FromOADate(0),
                City = "Long Beach",
                State = "California",
                Country = "USA",
                Question1 = "What is your favorite color?",
                Answer1 = "Blue",
                Question2 = "Where were you born?",
                Answer2 = "Long Beach",
                Question3 = "What is your favorite food?",
                Answer3 = "Tacos",
                IsAccountActivated = true,
                ClaimID = 1,
                RoleID = 1,
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}