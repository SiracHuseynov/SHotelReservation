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
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x=>x.IsDeleted).HasDefaultValue(false);
            builder.Property(x=> x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x=> x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x=> x.RedirectText).IsRequired().HasMaxLength(50);
            builder.Property(x=> x.Icon).IsRequired().HasMaxLength(100); 
            builder.Property(x=> x.Description).IsRequired().HasMaxLength(100);

        }
    }
}
