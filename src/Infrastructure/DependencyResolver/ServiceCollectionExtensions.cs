using Domain.DependencyResolver;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDatabaseContext();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
        }
    }
}
