using MediatR;

namespace Hotel.Application.Commands.Rooms.DeleteRoom
{
    public class DeleteRoomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
