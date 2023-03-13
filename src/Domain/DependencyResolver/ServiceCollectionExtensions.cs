using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Domain.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<ContextDatabase>(options => options.UseInMemoryDatabase("memory-db"));

            // SEED DATABASE
            var dbContext = services.BuildServiceProvider().GetRequiredService<ContextDatabase>();
            var userId = Guid.NewGuid();
            var user = new User
            {
                Id = userId,
                Email = "user_a@mail.com",
                FirstName = "User",
                LastName = "Test1",
                Active = true
            };
            dbContext.Users.Add(user);

            dbContext.Teams.Add(new Team
            {
                Id = Guid.NewGuid(),
                Name = "Team A",
                Department = "Tech",
                Active = true,
                Users = new List<User> { user }
            });
            dbContext.SaveChanges();
        }
    }
}
