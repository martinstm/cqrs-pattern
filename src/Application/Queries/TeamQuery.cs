using Application.Models;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Queries
{
    internal class TeamQuery : ITeamQuery
    {
        private readonly ITeamRepository _teamRepository;

        public TeamQuery(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IReadOnlyCollection<TeamReadDto>> GetAllAsync()
        {
            return (await _teamRepository.GetAllAsync()).Select(MapTeam).ToList();
        }

        private TeamReadDto MapTeam(Team team)
        {
            return new TeamReadDto
            {
                Active = team.Active,
                Department = team.Department,
                Name = team.Name,
                Users = team.Users.Select(MapUser).ToList()
            };
        }

        private UserReadDto MapUser(User user)
        {
            return new UserReadDto
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Active = user.Active,
                Email = user.Email
            };
        }
    }
}
