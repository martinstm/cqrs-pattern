using Application.Commands;
using Application.Commands.UserCommands;
using Application.Models;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSPattern.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserQuery _userQuery;
        private readonly ICommandProcessor _commandProcessor;

        public UserController(IUserQuery userQuery, ICommandProcessor commandProcessor)
        {
            _userQuery = userQuery;
            _commandProcessor = commandProcessor;
        }

        [HttpGet("all")]
        public async Task<IReadOnlyCollection<UserReadDto>> GetAllAsync()
        {
            return await _userQuery.GetAllAsync();
        }

        [HttpPost]
        public async Task Create(UserWriteDto user)
        {
            var insertUserCommand = new InsertUserCommand
            {
                Active = user.Active,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            await _commandProcessor.ProcessAsync(insertUserCommand);
        }
    }
}
