using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage25.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId {get; set;}
        public string RegNo {get; set;}
        public string Brand { get; set; }
        public string Color { get; set; }
        public int VehicleTypeId { get; set; }
        public int OwnerId { get; set; }

        public virtual VehicleType VehicleType {get; set;}
        public virtual Owner Owner { get; set; }
    }
}
// public virtual ICollection<Enrollment> Enrollments { get; set; }