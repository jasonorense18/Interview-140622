using Ct.Interview.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace Ct.Interview.Infrastructure.Services
{
    public class HttpService : IHttpService
    {
        private readonly AsxSettings _asxSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IOptions<AsxSettings> asxSettings, IHttpClientFactory httpClientFactory)
        {
            _asxSettings = asxSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Stream?> GetCompanyDetailsFromUrl()
        {
            var httpClient = _httpClientFactory.CreateClient(AsxSettings.ClientName);
            var response = await httpClient.GetAsync(_asxSettings.ListedSecuritiesCsvUrl);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            return await response.Content.ReadAsStreamAsync();
        }

        private static HttpClient SetupHttpClient()
        {
            var client = new HttpClient();
            return client;
        }
    }
}
