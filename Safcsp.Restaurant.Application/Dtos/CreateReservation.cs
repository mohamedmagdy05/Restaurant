using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Application.Dtos
{
    public class CreateReservation
    {
        public int GuestsNumber { get; set; }
        public DateTime ReservationDate { get; set; }

        public List<int> MenuTypeId { get; set; }
        public String Notes { get; set; }

    }
}
