using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Safcsp.Restaurant.Application.Dtos
{
    public class UserSignUp
    {
        [Required]
        public string Email { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
