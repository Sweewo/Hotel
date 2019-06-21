using Hotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Persistance.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.DateFrom).IsRequired();

            builder.Property(e => e.DateTo).IsRequired();

            builder.Property(e => e.RoomId).IsRequired();

            builder.Property(e => e.GuestId).IsRequired(false);

            builder.Property(e => e.ManagerId).IsRequired(false);
        }
    }
}
