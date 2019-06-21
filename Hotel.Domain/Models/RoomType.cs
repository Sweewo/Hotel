using System.Collections.Generic;

namespace Hotel.Domain.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Cost { get; set; }
        public string Categories { get; set; }
        public string Facilities { get; set; }
        public int Size { get; set; }
        public string BedType { get; set; }
        public string Image { get; set; }
        public IList<Room> Rooms { get; private set; } = new List<Room>();
    }
}
