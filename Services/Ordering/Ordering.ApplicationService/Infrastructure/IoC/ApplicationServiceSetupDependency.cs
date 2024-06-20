using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.ApplicationService.CQRS.Orders.Commands.Checkout;
using Ordering.ApplicationService.Infrastructure.MediatR.PipelineBehavior;
using Ordering.ApplicationService.Mapping;
using System.Reflection;

namespace Ordering.ApplicationService.Infrastructure.IoC
{
    public static class ApplicationServiceSetupDependency
    {
        public static IServiceCollection AddApplicationServiceDependency(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(OrderProfile));
            services.AddValidatorsFromAssembly(assembly: typeof(CheckoutOrderCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnHandledExeptionBehavior<,>));

            return services;
        }
    }
}
