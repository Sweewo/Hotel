using AutoMapper;
using Hotel.Application.Exceptions;
using Hotel.Application.Interfaces;
using Hotel.Application.Queries.Users.GetUser;
using Hotel.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IHotelDbContext context;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IHotelDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Users.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            entity.Email = request.Email;
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.AdditionalInfo = request.AdditionalInfo;

            await context.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserViewModel>(entity);
        }
    }
}
