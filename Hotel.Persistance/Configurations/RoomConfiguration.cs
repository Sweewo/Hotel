using Hotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Persistance.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.Number).IsUnique();

            builder.Property(e => e.Number).IsRequired();

            builder.Property(e => e.Floor).IsRequired();

            builder.Property(e => e.RoomTypeId).IsRequired();
        }
    }
}
