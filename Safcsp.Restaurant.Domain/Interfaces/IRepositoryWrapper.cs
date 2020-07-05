using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IReservationRepository Reservation { get; }
        IMenuTypeRepository MenuType { get; }

        IReservationMenuType ReservationMenuType { get; }
        Task<int> Save();

    }
}
