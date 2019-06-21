using Hotel.Application.Commands.Users.CreateUser;
using Hotel.Application.Commands.Users.UpdateUser;
using Hotel.Application.Commands.Users.UploadUserImage;
using Hotel.Application.Queries.Users.GetUser;
using Hotel.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Web.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("me"), Authorize]
        public async Task<ActionResult<UserViewModel>> Get()
        {
            var accesToken = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var id = IdFromClaimsResolver.Resolve(httpContextAccessor as HttpContextAccessor);

            var user = await Mediator.Send(new GetUserQuery { Id = id });

            if (user is null)
                user = await Mediator.Send(new CreateUserCommand { Token = accesToken });

            return Ok(user);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult<UserViewModel>> Update([FromBody] UpdateUserCommand command)
        {
            command.Id = IdFromClaimsResolver.Resolve(httpContextAccessor as HttpContextAccessor);

            return Ok(await Mediator.Send(command));
        }

        [HttpPost("image"), Authorize]
        public async Task<ActionResult<string>> UploadImage(IFormFile file)
        {
            var id = IdFromClaimsResolver.Resolve(httpContextAccessor as HttpContextAccessor);

            return Ok(await Mediator.Send(new UploadUserImageCommand() { Id = id, ImageFile = file }));
        }
    }
}
