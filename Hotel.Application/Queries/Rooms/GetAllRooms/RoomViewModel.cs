using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Models;

namespace Hotel.Application.Queries.Rooms.GetAllRooms
{
    public class RoomViewModel : ICustomMapping
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public string RoomType { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Room, RoomViewModel>()
               .ForMember(uvm => uvm.RoomType, m => m.MapFrom(u => u.RoomType.Code))
                ;
        }
    }
}
