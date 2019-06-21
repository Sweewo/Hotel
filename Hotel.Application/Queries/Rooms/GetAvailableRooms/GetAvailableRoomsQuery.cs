using Hotel.Application.Queries.Rooms.GetAllRooms;
using MediatR;
using System;
using System.Collections.Generic;

namespace Hotel.Application.Queries.Rooms.GetAvailableRooms
{
    public class GetAvailableRoomsQuery : IRequest<IEnumerable<RoomViewModel>>
    {
        public DateTime In { get; set; }
        public DateTime Out { get; set; }
        public string Code { get; set; }
    }
}
