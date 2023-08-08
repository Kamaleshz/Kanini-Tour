using Microsoft.EntityFrameworkCore;
using Travellers.Models;

namespace Travellers.Context
{
    public class TravellerContext : DbContext
    {
        public DbSet<Traveller> Travellers { get; set; }

        public TravellerContext(DbContextOptions<TravellerContext> options) : base(options) { }
    }
}
