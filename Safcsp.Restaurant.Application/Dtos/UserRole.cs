using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Safcsp.Restaurant.Application.Dtos
{
    public class UserRole
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
    }
}
