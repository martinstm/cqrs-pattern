using Application.Commands;
using Application.Commands.TeamCommands;
using Application.Commands.TeamCommands.Handlers;
using Application.Commands.UserCommands;
using Application.Commands.UserCommands.Handlers;
using Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserQuery, UserQuery>();
            services.AddTransient<ITeamQuery, TeamQuery>();

            services.AddCommands();
            services.AddTransient<ICommandProcessor, CommandProcessor>();
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<InsertUserCommand>, InsertUserCommandHandler>();
            services.AddTransient<ICommandHandler<InsertTeamCommand>, InsertTeamCommandHandler>();
        }
    }
}
