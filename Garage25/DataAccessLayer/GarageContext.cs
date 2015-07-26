using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Garage25.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public DbSet<Models.Vehicle> Vehicles { get; set; }
        public DbSet<Models.Owner> Owners { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }

  
        public GarageContext()
            : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
       

    }
}