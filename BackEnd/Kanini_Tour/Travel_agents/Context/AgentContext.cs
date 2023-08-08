using Microsoft.EntityFrameworkCore;
using Tour_Package.Models;

namespace Tour_Package.Context
{
    public class AgentContext : DbContext
    {
        public DbSet<Travel_agent> travel_agents { get; set; }

        public DbSet<Location> locations { get; set; }

        public DbSet<Package> packages { get; set; }

        public DbSet<Spots> spots { get; set; }


        public AgentContext(DbContextOptions<AgentContext> options) : base(options) { }
    }
}
