using Hotel.Application.Queries.Rooms.GetAllRooms;
using MediatR;

namespace Hotel.Application.Commands.Rooms.CreateRoom
{
    public class CreateRoomCommand : IRequest<RoomViewModel>
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public string RoomType { get; set; }
    }
}
