

using Microsoft.EntityFrameworkCore;
using PricedCodes2Project.DataAccess.Models;

namespace PricedCodes2Project.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Property> Property{ get; set; }
        public DbSet<PostCodePosition> PostcodePosition { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//conn string removed
             optionsBuilder.UseSqlServer();

        }
      } 
 }

