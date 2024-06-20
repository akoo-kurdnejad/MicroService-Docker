using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.DataAccess.EF.DBContext
{
    public static class DbContextIoC
    {
        public static void AddDbContextIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderingDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString"));
                options.EnableSensitiveDataLogging();
            });
        }

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<OrderingDBContext>();
                OrderContextSeed.SeedAsync(dbContext).Wait();
                dbContext.Database.Migrate();
            }
        }
    }
}
