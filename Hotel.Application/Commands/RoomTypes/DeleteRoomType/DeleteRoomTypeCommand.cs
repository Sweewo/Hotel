using MediatR;

namespace Hotel.Application.Commands.RoomTypes.DeleteRoomType
{
    public class DeleteRoomTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
