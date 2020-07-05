using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Domain.Entities
{
    public class Reservation
    {

        public int Id { get; set; }
        public int GuestsNumber { get; set; }
        public DateTime ReservationDate { get; set; }

        public ICollection<ReservationMenuType> ReservationMenuType { get; set; }
        public String Notes { get; set; }

    }
}
