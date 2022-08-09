using Ct.Interview.Application.Common.Interfaces.Persistence;
using Ct.Interview.Application.Common.Interfaces.Services;
using Ct.Interview.Infrastructure.Persistence.InMemory;
using Ct.Interview.Infrastructure.Services;
using Ct.Interview.Infrastructure.Services.CsvHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ct.Interview.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<AsxSettings>(configuration.GetSection(AsxSettings.SectionName));

            services.AddSingleton<IHttpService, HttpService>();
            services.AddScoped<IAsxCompanyRepository, AsxCompanyInMemoryRepository>();
            services.AddScoped<ICsvHelperService, CsvHelperServices>();

            services.AddHttpClient(AsxSettings.ClientName, client =>
            {
                client.BaseAddress = new Uri(configuration[$"{AsxSettings.SectionName}:BaseUrl"]);
            });

            return services;
        }
    }
}
