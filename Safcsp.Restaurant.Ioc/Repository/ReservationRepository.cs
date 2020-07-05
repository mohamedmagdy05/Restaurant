using Safcsp.Restaurant.Domain.Entities;
using Safcsp.Restaurant.Domain.Interfaces;
using Safcsp.Restaurant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Ioc.Repository
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(RestaurantDbContext Context) : base(Context)
        {
        }
    }
}
