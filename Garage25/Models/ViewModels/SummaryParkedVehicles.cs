using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage25.Models.ViewModels
{
    public class SummaryParkedVehicles
    {

        public int Id { get; set; }

        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleTypeName { get; set; }

        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        //[Display(Name = "Parked Time")]
        //public TimeSpan ParkedTime { get; set; }

        
        public int Days { get; set; }

        [DisplayFormat(DataFormatString = "{0:00}")]
        public int Hours { get; set; }
        [DisplayFormat(DataFormatString = "{0:00}")]
        public int Minutes { get; set; }
    }
}