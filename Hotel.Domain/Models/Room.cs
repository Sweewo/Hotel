using System.Collections.Generic;

namespace Hotel.Domain.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public IList<Booking> Bookings { get; private set; } = new List<Booking>();
    }
}
