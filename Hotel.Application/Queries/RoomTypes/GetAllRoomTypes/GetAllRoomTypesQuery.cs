using MediatR;
using System.Collections.Generic;

namespace Hotel.Application.Queries.RoomTypes.GetAllRoomTypes
{
    public class GetAllRoomTypesQuery : IRequest<IEnumerable<RoomTypeViewModel>>
    {
    }
}
