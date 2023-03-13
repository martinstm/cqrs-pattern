using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ContextDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        public ContextDatabase(DbContextOptions dbContextOptions) 
            : base(dbContextOptions) 
        { 
        
        }
    }
}
