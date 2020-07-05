using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Domain.Entities
{
    public class ReservationMenuType
    {
        public int MenuTypeId { get; set; }
        public MenuType MenuType { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
