using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage25.Models;

namespace Garage25.DataAccessLayer
{
    public class GarageContext : DbContext
    {
        public GarageContext()
            : base ("GarageContext")
        {
        }
        
        public DbSet<Color> Colors { get; set; }
        public DbSet<ParkedVehicle> ParkedVehicls { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<VehicleType> VechicleTypes { get; set; }
    }
}