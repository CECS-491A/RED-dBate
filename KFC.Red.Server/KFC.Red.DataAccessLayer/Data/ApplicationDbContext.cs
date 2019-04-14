using KFC.Red.DataAccessLayer.Models;
using System.Data.Entity;

namespace KFC.Red.DataAccessLayer.Data
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
        public DbSet<Question> Questions { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<UserGameStorage> UserGameStorages { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}