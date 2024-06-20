using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.ApplicationService.Infrastructure.IoC;
using Ordering.DataAccess.Infrastructure;

namespace Ordering.IoC
{
    public static class DependencyContainer
    {
        public static void AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServiceDependency();
            services.AddDataAccessDependency(configuration);
        }
    }
}
