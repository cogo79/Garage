using Garage25.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage25.DataAccessLayer
{
    public class GarageInitializer : DropCreateDatabaseIfModelChanges<GarageContext>
    {


        protected override void Seed(GarageContext context)
        {
         
            var owners = new List<Owner>
            {
                new Owner { Fname = "Ulle", Lname="Andersson", TelNo ="0785990" },
                new Owner { Fname = "Olof", Lname="Eirksson", TelNo ="076588l" },
                new Owner { Fname = "Oscar", Lname="Cososky", TelNo ="0787950" },
                new Owner { Fname = "Maria", Lname="Olle", TelNo ="0776509" },
            };
            owners.ForEach(s => context.Owners.Add(s));
            context.SaveChanges();

            var vehicleTypes = new List<VehicleType>
            {
                new VehicleType {TypeDes = "Car" },
                new VehicleType {TypeDes = "Motorcycle" },
                new VehicleType {TypeDes = "Airplane" },
                new VehicleType {TypeDes = "Buss" },
                 new VehicleType {TypeDes = "Boat" }
               
            };
            vehicleTypes.ForEach(s => context.VehicleTypes.Add(s));
            context.SaveChanges();

            var vehicles = new List<Vehicle>
            {
                new Vehicle { RegNo="ABS163", Brand="Volvo", Color = "Blue", OwnerId = 2, VehicleTypeId = 1},
                new Vehicle { RegNo="CVD765", Brand="Toyta", Color = "Red" , OwnerId = 1, VehicleTypeId = 2},
                new Vehicle { RegNo="fgh745", Brand="Eskoda", Color = "Blackgreen", OwnerId = 2, VehicleTypeId = 3},  
                new Vehicle { RegNo="jkr768", Brand="Folkwagn", Color = "White", OwnerId = 3, VehicleTypeId = 4},
            };
            vehicles.ForEach(s => context.Vehicles.Add(s));
            context.SaveChanges();
        }


    }
}