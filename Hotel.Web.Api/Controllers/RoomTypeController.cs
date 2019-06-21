using Hotel.Application.Commands.RoomTypes.CreateRoomType;
using Hotel.Application.Commands.RoomTypes.DeleteRoomType;
using Hotel.Application.Commands.RoomTypes.UpdateRoomType;
using Hotel.Application.Commands.RoomTypes.UploadRoomTypeImage;
using Hotel.Application.Queries.RoomTypes.GetAllRoomTypes;
using Hotel.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Web.Api.Controllers
{
    [Route("api/room-type/")]
    public class RoomTypeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRoomTypesQuery()));
        }

        [HttpPost, Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<RoomTypeViewModel>> Create([FromBody] CreateRoomTypeCommand command)
        {
            var roomType = await Mediator.Send(command);

            return Ok(roomType);
        }

        [HttpPut, Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<RoomTypeViewModel>> Update([FromBody] UpdateRoomTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}"), Authorize(Roles = RoleHelper.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoomTypeCommand { Id = id });

            return NoContent();
        }

        [HttpPost("{id}/image"), Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<string>> UploadImage(IFormFile file, int id)
        {
            return Ok(await Mediator.Send(new UploadRoomTypeImageCommand() { Id = id, ImageFile = file }));
        }

    }
}
