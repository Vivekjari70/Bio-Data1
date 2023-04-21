using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bio_Data.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Plaese Enter Email")]
        [Remote(action: "EmailIsExist", controller: "Home")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please Enter Valid Email.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
