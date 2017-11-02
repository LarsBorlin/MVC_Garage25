using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage25.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Color")]
        [RegularExpression(@"^[A-Ö]+[a-öA-Ö''- '\s]*$")]
        public string Name { get; set; }
    }
}