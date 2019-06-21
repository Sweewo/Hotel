using Hotel.Application.Commands.Rooms.CreateRoom;
using Hotel.Application.Commands.Rooms.DeleteRoom;
using Hotel.Application.Commands.Rooms.UpdateRoom;
using Hotel.Application.Queries.Rooms.GetAllRooms;
using Hotel.Application.Queries.Rooms.GetAvailableRooms;
using Hotel.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Web.Api.Controllers
{
    public class RoomController : BaseController
    {
        [HttpGet, Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<IEnumerable<RoomViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRoomsQuery()));
        }

        [HttpPost, Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<RoomViewModel>> Create([FromBody] CreateRoomCommand command)
        {
            var roomType = await Mediator.Send(command);

            return Ok(roomType);
        }

        [HttpPut, Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<RoomViewModel>> Update([FromBody] UpdateRoomCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}"), Authorize(Roles = RoleHelper.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoomCommand { Id = id });

            return NoContent();
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<RoomViewModel>>> GetAvailableRooms([FromQuery]GetAvailableRoomsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}

