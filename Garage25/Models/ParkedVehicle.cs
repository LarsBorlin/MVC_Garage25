using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage25.Models
{

    //public enum Color
    //{
    //    Black,
    //    Blue,
    //    Red,
    //    White,
    //    Greeen
    //}

    public class ParkedVehicle
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Vehicle brand")]
        [RegularExpression(@"^[A-Ö]+[a-öA-Ö''- '\s]*$")]
        public string VehicleBrand { get; set; }

        [Required]
        [Display(Name = "Parking Date and Time")]
        public DateTime InDate { get; set; }        

        public int ColorId { get; set; }

        [Display(Name = "Parking Spot Number")]
        public int ParkingSpot { get; set; }

        public int VehicleTypeId { get; set; }
    }
}