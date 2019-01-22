using CECS491_DBate.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CECS491_DBate.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ProjectConnection") { }
        public DbSet<User> Users { get; set; }
    }
}