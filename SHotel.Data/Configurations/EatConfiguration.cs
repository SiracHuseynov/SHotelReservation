using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHotel.Data.Configurations
{
    public class EatConfiguration : IEntityTypeConfiguration<Eat>
    {
        public void Configure(EntityTypeBuilder<Eat> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.EatCategoryId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x=> x.ImageUrl).IsRequired();

        }
    }
}
