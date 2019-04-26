namespace KFC.RED.DataAccessLayer.Migrations
{
    using KFC.Red.DataAccessLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KFC.Red.DataAccessLayer.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KFC.Red.DataAccessLayer.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Questions.AddOrUpdate(x => x.QuestionID,
                new Question() { QuestionID = 1, QuestionString = "Question 1?" },
                new Question() { QuestionID = 2, QuestionString = "Question 2?" },
                new Question() { QuestionID = 3, QuestionString = "Question 3?" });

            context.Users.AddOrUpdate(x => x.ID,
                new User()
                {
                    ID = 1,
                    SsoId = Guid.NewGuid(),
                    Username = "Christian",
                    Email = "1@gmail.com",
                    PasswordHash = "",
                    PasswordSalt = "",
                    DateOfBirth = DateTime.UtcNow,
                    City = "Long Beach",
                    State = "CA",
                    Country = "United States",
                    Role = "",
                },
                new User()
                {
                    ID = 2,
                    SsoId = Guid.NewGuid(),
                    Username = "Deivis",
                    Email = "2@gmail.com",
                    PasswordHash = "",
                    PasswordSalt = "",
                    DateOfBirth = DateTime.UtcNow,
                    City = "Long Beach",
                    State = "CA",
                    Country = "United States",
                    Role = "",
                },
                new User()
                {
                    ID = 3,
                    SsoId = Guid.NewGuid(),
                    Username = "Luis",
                    Email = "3@gmail.com",
                    PasswordHash = "",
                    PasswordSalt = "",
                    DateOfBirth = DateTime.UtcNow,
                    City = "Long Beach",
                    State = "CA",
                    Country = "United States",
                    Role = "",
                });
        }
    }
}
