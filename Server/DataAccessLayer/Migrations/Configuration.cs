namespace KFC.RED.DataAccessLayer.Migrations
{
    using KFC.Red.DataAccessLayer.Data;
    using KFC.Red.DataAccessLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(x => x.ID,
                new User() { ID = 1, Name = "Jane Austen", Username = "ja2080@gmail.com", DateOfBirth = new DateTime(1996,12,15), IsAccountActivated = true },
                new User() { ID = 2, Name = "Charles Dickens", Username = "cd2080@gmail.com", DateOfBirth = new DateTime(1996, 12, 15), IsAccountActivated = true },
                new User() { ID = 3, Name = "Miguel de Cervantes", Username = "mdc2080@gmail.com", DateOfBirth = new DateTime(1996, 12, 15), IsAccountActivated = true }
            );
        }
    }
}
