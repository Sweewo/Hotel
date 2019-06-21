using Hotel.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly HotelDbContext context;

        public CommandTestBase()
        {
            context = HotelContextFactory.Create();
        }

        public void Dispose()
        {
            HotelContextFactory.Destroy(context);
        }
    }
}
