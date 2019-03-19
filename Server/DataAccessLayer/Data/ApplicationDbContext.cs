using KFC.Red.DataAccessLayer.Models;
using System.Data.Entity;

namespace KFC.Red.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            this.Database.Connection.ConnectionString = "Data Source=localhost;Initial Catalog=DBate;Integrated Security=True";
            //Database.SetInitializer(new DBateDBInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Connection> Connections { get; set; }
    }
}