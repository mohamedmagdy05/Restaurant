using Safcsp.Restaurant.Domain.Entities;
using Safcsp.Restaurant.Domain.Interfaces;
using Safcsp.Restaurant.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Ioc.Repository
{
    public class MenuTypeRepository : BaseRepository<MenuType> , IMenuTypeRepository
    {
        public MenuTypeRepository(RestaurantDbContext Context) : base(Context)
        {
        }
    }
}
