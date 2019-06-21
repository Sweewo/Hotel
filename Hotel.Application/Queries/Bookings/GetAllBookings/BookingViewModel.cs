using AutoMapper;
using Hotel.Application.Interfaces.Mapping;
using Hotel.Domain.Models;
using System;

namespace Hotel.Application.Queries.Bookings.GetAllBookings
{
    public class BookingViewModel : ICustomMapping
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Guest { get; set; }
        public string Manager { get; set; }
        public string Room { get; set; }
        public string RoomType { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Booking, BookingViewModel>()
                .ForMember(vm => vm.Guest, m => m.MapFrom(b => b.Guest.Username))
                .ForMember(vm => vm.Manager, m => m.MapFrom(b =>b.Manager.Username))
                .ForMember(vm => vm.Room, m => m.MapFrom(b => b.Room.Number))
                .ForMember(vm => vm.RoomType, m => m.MapFrom(b => b.Room.RoomType.Code))
                ;
        }
    }
}
