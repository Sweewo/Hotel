using MediatR;
using System.Collections.Generic;

namespace Hotel.Application.Queries.Rooms.GetAllRooms
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<RoomViewModel>>
    {
    }
}
