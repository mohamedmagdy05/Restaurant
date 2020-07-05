using Safcsp.Restaurant.Domain.Entities;
using Safcsp.Restaurant.Domain.Interfaces;
using Safcsp.Restaurant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Ioc.Repository
{
    public class ReservationMenuTypeRepository : BaseRepository<ReservationMenuType>, IReservationMenuType
    {
        public ReservationMenuTypeRepository(RestaurantDbContext Context) : base(Context)
        {
        }
    }
}
