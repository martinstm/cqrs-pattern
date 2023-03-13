using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class TeamRepository : ITeamRepository
    {
        private readonly ContextDatabase _contextDatabase;

        public TeamRepository(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public async Task<IReadOnlyCollection<Team>> GetAllAsync()
        {
            return await _contextDatabase.Teams.Include(t => t.Users).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Team>> GetByUserIdAsync(Guid userId)
        {
            return await _contextDatabase.Teams.Include(x => x.Users.Select(x => x.Id).Contains(userId)).ToListAsync();
        }

        public async Task InsertAsync(Team team)
        {
            await _contextDatabase.Teams.AddAsync(team);
            await _contextDatabase.SaveChangesAsync();
        }
    }
}
