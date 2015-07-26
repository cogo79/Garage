using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage25.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string TelNo { get; set; }
    }
}