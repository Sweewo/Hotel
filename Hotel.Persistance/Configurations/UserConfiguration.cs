using Hotel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.AdditionalInfo);

            builder.Property(e => e.Email).HasMaxLength(255);

            builder.Property(e => e.Username).HasMaxLength(255);

            builder.Property(e => e.FirstName).HasMaxLength(255);

            builder.Property(e => e.LastName).HasMaxLength(255);
        }
    }
}
