using AutoMapper;
using Hotel.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public GetUserQueryHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync(request.Id);

            return user is null ? null : mapper.Map<UserViewModel>(user);
        }
    }
}
