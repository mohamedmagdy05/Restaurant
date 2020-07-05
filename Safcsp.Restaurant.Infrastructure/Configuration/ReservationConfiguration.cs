using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Infrastructure.Configuration
{
    /// <summary>
    ///  Reservation entity fluent api Configuration
    /// </summary>
    class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(p => p.GuestsNumber).IsRequired();
            builder.Property(p => p.ReservationDate).IsRequired();
            builder.Property(p => p.Notes).HasMaxLength(300);
           }
    }
}
