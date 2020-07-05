using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Safcsp.Restaurant.Infrastructure
{
    /// <summary>
    /// APi Database context configuration 
    /// </summary>
    public class RestaurantDbContext : IdentityDbContext<User, Role, Guid>
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Reservation> Reservations;
        public DbSet<MenuType> MenuTypes;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
