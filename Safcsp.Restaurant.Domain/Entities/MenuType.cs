using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Domain.Entities
{
    public class MenuType
    {
 

        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<ReservationMenuType> ReservationMenuType { get; set; }

    }
}
