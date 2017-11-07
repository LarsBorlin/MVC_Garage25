using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garage25.Models;
using System.ComponentModel.DataAnnotations;

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
      //  [RegularExpression(@"^[A-Z]+[a-zA-Z''- '\s]*$")]
        public string VehicleBrand { get; set; }

        [Required]
        [Display(Name = "Parking Date and Time")]
        public DateTime InDate { get; set; }

        [Display(Name = "Parking Spot Number")]
        public int ParkingSpot { get; set; }

        [Display(Name = "Vehicle Type")]
        public int VehicleTypeId { get; set; }
        public int PersonId { get; set; }
        public int ColorId { get; set; }


        public virtual Color Color { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual Person Person { get; set; }


    }


}