using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Display(Name ="First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        public string Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
