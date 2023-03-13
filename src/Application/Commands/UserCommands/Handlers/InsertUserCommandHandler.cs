using Domain;
using Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Application.Commands.UserCommands.Handlers
{
    internal class InsertUserCommandHandler : ICommandHandler<InsertUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public InsertUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task HandleAsync(InsertUserCommand command)
        {
            var user = new User
            {
                Active = command.Active,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Id = Guid.NewGuid()
            };

            await _userRepository.InsertAsync(user);
        }
    }
}
