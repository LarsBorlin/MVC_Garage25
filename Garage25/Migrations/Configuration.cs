namespace Garage25.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Garage25.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage25.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage25.DataAccessLayer.GarageContext context)
        {
            //context.Persons.AddOrUpdate(
            //    )

            //context.Persons.AddOrUpdate(
            //p => p.Id,
            //new Person { Id = 1, FirstName = "Olle", LastName = "Olleson", MailAddress = "olle.olleson@olle.com", Password = "olle" });


            // context.ParkedVehicls.AddOrUpdate(
            //p => p.Id,
            //new ParkedVehicle { Id = 1, RegistrationNumber = "ABC 123", VehicleBrand = "Volvo", InDate = DateTime.Now, ParkingSpot = 1, VehicleTypeId = 1, PersonId=1, ColorId = 1 });

            //context.Persons.AddOrUpdate(
            //p => p.Id,
            //new Person { FirstName = "Olle", LastName = "Olleson", MailAddress = "olle.olleson@olle.com", Password = "olle", },
            //new Person { FirstName = "Kalle", LastName = "Kalleson", MailAddress = "kalle.kalleson@kalle.com", Password = "kalle", });


            context.Colors.AddOrUpdate(
            c => c.Id,
            new Color { Id = 1, Name = "Red" },
            new Color { Id = 2, Name = "Blue" });

            context.VechicleTypes.AddOrUpdate(
                v => v.Id,
                new VehicleType { Id = 1, TypeName = "Car", ParkingSpace = 1 },
                new VehicleType { Id = 2, TypeName = "Bus", ParkingSpace = 2 },
                new VehicleType { Id = 3, TypeName = "Boat", ParkingSpace = 2 },
                new VehicleType { Id = 4, TypeName = "Airplane", ParkingSpace = 3 },
                new VehicleType { Id = 5, TypeName = "Motorcycle", ParkingSpace = 1 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
