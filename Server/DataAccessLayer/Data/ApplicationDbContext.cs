using KFC.Red.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KFC.Red.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name = DBateConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}