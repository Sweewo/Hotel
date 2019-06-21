using AutoMapper;
using Hotel.Application.Interfaces;
using Hotel.Application.Interfaces.ApiClients.Users;
using Hotel.Application.Queries.Users.GetUser;
using Hotel.Common;
using Hotel.Domain.Enums;
using Hotel.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;
        private readonly IUserApiService service;
        private readonly IDateTime dateTime;

        public CreateUserCommandHandler(IHotelDbContext context, IMapper mapper, IUserApiService service, IDateTime dateTime)
        {
            this.context = context;
            this.mapper = mapper;
            this.service = service;
            this.dateTime = dateTime;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await service.LoadUserFromAuthServerAsync(request.Token);

            if (user.UserType == UserType.Guest)
                user = new Guest(user) { RegisterDate = dateTime.Now };
            else
                user = new Manager(user);

            context.Users.Add(user);

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserViewModel>(user);
        }
    }
}
