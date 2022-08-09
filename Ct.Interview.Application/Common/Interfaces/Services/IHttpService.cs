namespace Ct.Interview.Application.Common.Interfaces.Services
{
    public interface IHttpService
    {
        Task<Stream?> GetCompanyDetailsFromUrl();
    }
}
