namespace Ct.Interview.Application.Common.Interfaces.Services
{
    public interface ICsvHelperService
    {
        List<Domain.Entities.AsxCompany> GetAsxCompanyList(Stream stream);
    }
}