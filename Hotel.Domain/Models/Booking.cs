using System;

namespace Hotel.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RoomId { get; set; }
        public int? GuestId { get; set; }
        public int? ManagerId { get; set; }

        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public Manager Manager { get; set; }
    }
}
