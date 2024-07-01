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
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.PositionId).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.FbLink).HasMaxLength(100);
            builder.Property(x => x.TwitterLink).HasMaxLength(100);
            builder.Property(x => x.InstagramLink).HasMaxLength(100);


        }
    }
}
