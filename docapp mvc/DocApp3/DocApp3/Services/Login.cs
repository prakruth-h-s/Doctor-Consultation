using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp3.Services
{
    public class Login
    {
        [Remote("IsEmailExist", "Home", ErrorMessage = "email doesn't exist please register")]
        [EmailAddress, Required(ErrorMessage = "Email required"), Display(Name = "E-mail")]
        public string UserEmail { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Password required"), MinLength(8, ErrorMessage = "Password should me minimum of 8 characters")]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}
