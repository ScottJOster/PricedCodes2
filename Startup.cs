using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PricedCodes2Project.DataAccess.Context;

namespace PricedCodes2Project
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public IConfiguration? Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<AppDbContext>
           (o => o.UseSqlServer(Configuration.GetConnectionString("PricedCodes2Db")));
        }

    }
}
