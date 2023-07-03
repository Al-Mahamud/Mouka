using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mouka.Web.Models
{
    public class SettingModel
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Select City.")]
        public string City { get; set; }

    }
}