using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safcsp.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Infrastructure.Configuration
{
    /// <summary>
    ///  MenuType entity fluent api Configuration
    /// </summary>
    public class MenuTypeConfiguration : IEntityTypeConfiguration<MenuType>
    {
        public void Configure(EntityTypeBuilder<MenuType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
