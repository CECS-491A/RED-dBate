using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CECS491_DBate_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DBateConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<WeightMeasurement> WeightMeasurements { get; set; }
    }
}