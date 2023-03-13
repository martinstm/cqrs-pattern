using Application.Models;
using Domain;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Queries
{
    internal class UserQuery : IUserQuery
    {
        private readonly IUserRepository _userRepository;

        public UserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<UserReadDto>> GetAllAsync()
        {
            return (await _userRepository.GetAllAsync()).Select(MapUser).ToList();
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
