using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialMedia.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage =  "Name is Required!")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Compare("Password")]
        public string ComfirmPassword { get; set; }
        public string Message { get; set; }
    }
}