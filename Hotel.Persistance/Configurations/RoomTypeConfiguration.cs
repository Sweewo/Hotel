using Hotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Persistance.Configurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.Code).IsUnique();

            builder.Property(e => e.Code).IsRequired().HasMaxLength(255);

            builder.Property(e => e.BedType).HasMaxLength(255);

            builder.Property(e => e.Categories).HasMaxLength(255);
                                               
            builder.Property(e => e.Facilities).HasMaxLength(255);
        }
    }
}
