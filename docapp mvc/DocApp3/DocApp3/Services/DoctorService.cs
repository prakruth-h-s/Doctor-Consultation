using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp3.Services
{
    public class DoctorService
    {
        [Key]
        public string DoctorID { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "contact number required")]
        public long Contact { get; set; }

        [EmailAddress, Required(ErrorMessage = "email address required")]
        [Remote("IsEmailAvailable", "Doctors", HttpMethod = "POST", ErrorMessage = "Email already in use.")]
        public string Email { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "password required"), MinLength(8, ErrorMessage = "password should be minimum of 8 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Confirm password required"), MinLength(8, ErrorMessage = "confirm password should be minimum of 8 characters")]
        [Compare("Password", ErrorMessage = "password and confirm password should be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Specialization required")]
        public string Specialization { get; set; }
    }
}
