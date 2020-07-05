using Safcsp.Restaurant.Application.Dtos;
using Safcsp.Restaurant.Application.Interfaces;
using Safcsp.Restaurant.Domain.Entities;
using Safcsp.Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;

namespace Safcsp.Restaurant.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepositoryWrapper _ctx;

        public ReservationService(IRepositoryWrapper ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CreateReservation(CreateReservation res)
        {
            var Reservation = new Reservation()
            {
                GuestsNumber = res.GuestsNumber,
                ReservationDate = res.ReservationDate,
                Notes = res.Notes
                
            };

            await _ctx.Reservation.Add(Reservation);


            foreach (int m in res.MenuTypeId){

                var menutype =  await _ctx.MenuType.Get(m);

                var ResMenu = new ReservationMenuType()
                {
                    MenuType = menutype,
                    Reservation = Reservation
                };
               await _ctx.ReservationMenuType.Add(ResMenu);
            }

            var result = await _ctx.Save();
            if(result > 0)
            {
                return false;
            }
            return true;

        }

   
    }
}
