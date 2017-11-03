using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage25.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
     //   [RegularExpression(@"^[A-Ö]+[a-öA-Ö''- '\s]*$")]
        public string TypeName { get; set; }

        [Required]
        [Display(Name = "Parking place required")]
      //  [RegularExpression(@"^[0-9]+$")]
        public int ParkingSpace { get; set; }
    }
}