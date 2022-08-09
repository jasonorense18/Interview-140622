using Ct.Interview.Web.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ct.Interview.Web.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            //Override the DefaultProblemDetailsFactory from MVC to Custom ProblemDetailsFactory.
            services.AddSingleton<ProblemDetailsFactory, CtInterviewProblemDetailsFactory>();

            //services.AddMappings();
            return services;
        }
    }
}
