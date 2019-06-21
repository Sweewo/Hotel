using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Models;

namespace Hotel.Application.Queries.RoomTypes.GetAllRoomTypes
{
    public class RoomTypeViewModel : ICustomMapping
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Cost { get; set; }
        public string Categories { get; set; }
        public string Facilities { get; set; }
        public int Size { get; set; }
        public string BedType { get; set; }
        public string Image { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<RoomType, RoomTypeViewModel>();
        }
    }
}
