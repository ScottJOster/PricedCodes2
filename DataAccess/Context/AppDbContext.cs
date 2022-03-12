

using Microsoft.EntityFrameworkCore;
using PricedCodes2Project.DataAccess.Models;

namespace PricedCodes2Project.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PostCodePosition> Positions { get; set; }
    }
}
