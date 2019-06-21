using Hotel.Application.Commands.Bookings.CreateBooking;
using Hotel.Application.Queries.Bookings.GetAllBookings;
using Hotel.Application.Queries.Bookings.GetAllBookingsByGuest;
using Hotel.Web.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Web.Api.Controllers
{

    public class BookingController : BaseController
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BookingController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet, Authorize(Roles = RoleHelper.Admin)]
        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBookingsQuery()));
        }

        [HttpGet("guest"), Authorize]
        public async Task<ActionResult<IEnumerable<BookingGuestViewModel>>> GetAllByGuestId()
        {
            var id = IdFromClaimsResolver.Resolve(httpContextAccessor as HttpContextAccessor);

            return Ok(await Mediator.Send(new GetAllBookingsByGuestQuery { Id = id }));
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookingCommand command)
        {
            command.Id = IdFromClaimsResolver.Resolve(httpContextAccessor as HttpContextAccessor);

            return Ok(await Mediator.Send(command));
        }

      
    }
}
