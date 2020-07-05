using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public String FullName { get; set; }
    }
}
