using Safcsp.Restaurant.Application.Dtos;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Application.Interfaces
{
    public interface IReservationService
    {
        Task<bool> CreateReservation(CreateReservation res);
    }
}
