using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class UserRepository : IUserRepository
    {
        private readonly ContextDatabase _contextDatabase;

        public UserRepository(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _contextDatabase.Users.ToListAsync();
        }

        public async Task<IReadOnlyCollection<User>> GetAllByEmailsAsync(List<string> emails)
        {
            return await _contextDatabase.Users.Where(x => emails.Contains(x.Email)).ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _contextDatabase.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task InsertAsync(User user)
        {
            await _contextDatabase.Users.AddAsync(user);
            await _contextDatabase.SaveChangesAsync();
        }
    }
}