using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage25.Models
{
    public class VehicleType
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string TypeDes { get; set; }


    }
}