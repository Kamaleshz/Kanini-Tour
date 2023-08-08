using Admins.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admins.Context
{
    public class AdminContextClass : DbContext
    {
        public DbSet<Admins> Admins { get; set; }

        public AdminContextClass(DbContextOptions<AdminContextClass> options) : base(options) { }

    }
}
