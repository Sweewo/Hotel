using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Models;

namespace Hotel.Application.Queries.Bookings.GetAllBookingsByGuest
{
    public class BookingGuestRoomViewModel : ICustomMapping
    {
        public string Number { get; set; }
        public string Floor { get; set; }
        public string Code { get; set; }
        public string Categories { get; set; }
        public string Facilities { get; set; }
        public string BedType { get; set; }
        public int Cost { get; set; }
        public string Image { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Room, BookingGuestRoomViewModel>()
                .ForMember(vm => vm.Number, m => m.MapFrom(b => b.Number))
                .ForMember(vm => vm.Floor, m => m.MapFrom(b => b.Floor))
                .ForMember(vm => vm.Code, m => m.MapFrom(b => b.RoomType.Code))
                .ForMember(vm => vm.Categories, m => m.MapFrom(b => b.RoomType.Categories))
                .ForMember(vm => vm.Facilities, m => m.MapFrom(b => b.RoomType.Facilities))
                .ForMember(vm => vm.BedType, m => m.MapFrom(b => b.RoomType.BedType))
                .ForMember(vm => vm.Cost, m => m.MapFrom(b => b.RoomType.Cost))
                .ForMember(vm => vm.Image, m => m.MapFrom(b => b.RoomType.Image))
                ;
        }
    }
}
