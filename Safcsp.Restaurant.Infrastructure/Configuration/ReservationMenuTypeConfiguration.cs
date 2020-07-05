using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Infrastructure.Configuration
{
    public class ReservationMenuTypeConfiguration : IEntityTypeConfiguration<ReservationMenuType>
    {
        public void Configure(EntityTypeBuilder<ReservationMenuType> builder)
        {
            builder.HasKey(rb => new { rb.MenuTypeId, rb.ReservationId });
            builder.HasOne(rb => rb.MenuType).WithMany(rb => rb.ReservationMenuType).HasForeignKey(rb => rb.MenuTypeId);
            builder.HasOne(rb => rb.Reservation).WithMany(rb => rb.ReservationMenuType).HasForeignKey(rb => rb.ReservationId);

        }
    }
}
