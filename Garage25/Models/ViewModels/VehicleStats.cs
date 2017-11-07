using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage25.Models.ViewModels
{
    public class VehicleStats
    {
        public int Id { get; set; }

        [Display(Name = "Parked Time (min)")]
        public int ParkedTime { get; set; }
        [Display(Name = "Total Cost")]
        public int TotalParkedCost { get; set; }
        [Display(Name = "Registration Number")]
        public string RegNo { get; set; }
        public string VehType { get; set; }
        public int TotalNrOfWheels { get; set; }
    }
}