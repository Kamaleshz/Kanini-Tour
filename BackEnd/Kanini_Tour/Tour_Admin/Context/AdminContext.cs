using Microsoft.EntityFrameworkCore;
using Tour_Admin.Model;

namespace Tour_Admin.Context
{
    public class AdminContext : DbContext
    {
        public DbSet<Admin> admins { get; set; }

        public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }
    }
}
