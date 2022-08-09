using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ct.Interview.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Automatically register all MediatR 
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
