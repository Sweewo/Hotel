using Hotel.Application.Queries.Rooms.GetAllRooms;
using MediatR;

namespace Hotel.Application.Commands.Rooms.UpdateRoom
{
    public class UpdateRoomCommand : IRequest<RoomViewModel>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public string RoomType { get; set; }
    }
}
