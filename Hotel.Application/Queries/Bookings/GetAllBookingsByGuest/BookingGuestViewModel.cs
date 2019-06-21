using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Models;
using System;

namespace Hotel.Application.Queries.Bookings.GetAllBookingsByGuest
{
    public class BookingGuestViewModel : ICustomMapping
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public BookingGuestRoomViewModel Room { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Booking, BookingGuestViewModel>()
                .ForMember(vm => vm.Room, m => m.MapFrom(b => b.Room))
                ;
        }
    }
}
