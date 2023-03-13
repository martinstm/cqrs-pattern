using Application.Commands.UserCommands;
using Application.Commands;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Commands.TeamCommands;
using Application.Queries;
using System.Collections.Generic;

namespace CQRSPattern.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly ITeamQuery _teamQuery;

        public TeamController(ICommandProcessor commandProcessor, ITeamQuery teamQuery)
        {
            _commandProcessor = commandProcessor;
            _teamQuery = teamQuery;
        }

        [HttpGet("all")]
        public async Task<IReadOnlyCollection<TeamReadDto>> GetAllAsync()
        {
            return await _teamQuery.GetAllAsync();
        }

        [HttpPost]
        public async Task Create(TeamWriteDto team)
        {
            var insertTeamCommand = new InsertTeamCommand
            {
                Active = team.Active,
                Name = team.Name,
                Department = team.Department,
                UsersEmail = team.UsersEmail
            };

            await _commandProcessor.ProcessAsync(insertTeamCommand);
        }
    }
}
