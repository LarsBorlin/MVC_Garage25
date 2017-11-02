using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage25.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Mail Address")]
        [StringLength(100, MinimumLength =7, ErrorMessage ="Mail address cannot be less than 7 characters or more than 100")]
        public string MailAddress { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters")]
       // [RegularExpression(@"^[A-Z]+[a-zA-Z''- '\s]*$")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters")]
      //  [RegularExpression(@"^[A-Z]+[a-zA-Z''- '\s]*$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 12 Characters")]
        public string Password { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => (FirstName + " " + LastName).Trim();

        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}