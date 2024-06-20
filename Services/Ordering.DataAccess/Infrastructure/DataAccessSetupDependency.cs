using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.DataAccess.EF.DBContext;
using Ordering.DataAccess.Repositories;
using Ordering.DataAccess.Repositories.Base;
using Ordering.Domain.Repositories;
using Ordering.Domain.Repositories.Base;

namespace Ordering.DataAccess.Infrastructure
{
    public static class DataAccessSetupDependency
    {
        public static IServiceCollection AddDataAccessDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextIoC(configuration);
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
