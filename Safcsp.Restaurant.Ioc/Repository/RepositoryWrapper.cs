using Safcsp.Restaurant.Domain.Interfaces;
using Safcsp.Restaurant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Ioc.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RestaurantDbContext _ctx;
        private IReservationRepository _Reservation;
        private IMenuTypeRepository _MenuTpye;
        private IReservationMenuType _reservationMenuType;

        public RepositoryWrapper(RestaurantDbContext ctx)
        {
            _ctx = ctx;
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (_Reservation == null)
                {
                    _Reservation = new ReservationRepository(_ctx);
                }

                return _Reservation;
            }
        }

        public IMenuTypeRepository MenuType
        {
            get
            {
                if (_MenuTpye == null)
                {
                    _MenuTpye = new MenuTypeRepository(_ctx);
                }

                return _MenuTpye;
            }
        }

        public IReservationMenuType ReservationMenuType
        {
            get
            {
                if (_reservationMenuType == null)
                {
                    _reservationMenuType = new ReservationMenuTypeRepository(_ctx);
                }

                return _reservationMenuType;
            }
        }

        public async Task<int> Save()
        {
          return await  _ctx.SaveChangesAsync();

        }
    }
}
