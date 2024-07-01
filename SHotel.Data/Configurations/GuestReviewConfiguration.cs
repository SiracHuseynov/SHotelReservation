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
    public class GuestReviewConfiguration : IEntityTypeConfiguration<GuestReview>
    {
        public void Configure(EntityTypeBuilder<GuestReview> builder)
        {
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x=> x.FullName).IsRequired().HasMaxLength(50);

        }
    }
}
