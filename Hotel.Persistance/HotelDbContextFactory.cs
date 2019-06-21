using Hotel.Persistance.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Persistance
{
    public class HotelDbContextFactory : DesignTimeDbContextFactoryBase<HotelDbContext>
    {
        protected override HotelDbContext CreateNewInstance(DbContextOptions<HotelDbContext> options)
        {
            return new HotelDbContext(options);
        }
    }
}
