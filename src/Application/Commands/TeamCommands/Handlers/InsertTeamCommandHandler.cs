using Domain;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.TeamCommands.Handlers
{
    internal class InsertTeamCommandHandler : ICommandHandler<InsertTeamCommand>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;

        public InsertTeamCommandHandler(ITeamRepository teamRepository, IUserRepository userRepository)
        {
            _teamRepository = teamRepository;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(InsertTeamCommand command)
        {
            // validate users
            var users = await _userRepository.GetAllByEmailsAsync(command.UsersEmail);

            if(users == null || users.Count < command.UsersEmail.Count)
            {
                throw new Exception($"There were found ${users.Count} users which is less than the requested ${command.UsersEmail.Count}.");
            }

            var team = new Team
            {
                Id = Guid.NewGuid(),
                Active = command.Active,
                Department = command.Department,
                Name = command.Name,
                Users = users.ToList()
            };

            await _teamRepository.InsertAsync(team);
        }
    }
}
