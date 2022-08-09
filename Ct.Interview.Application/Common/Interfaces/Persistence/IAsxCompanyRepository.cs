namespace Ct.Interview.Application.Common.Interfaces.Persistence
{
    public interface IAsxCompanyRepository
    {
        void AddRange(List<Domain.Entities.AsxCompany> asxCompanies);
        Domain.Entities.AsxCompany? GetByCode(string code);
    }
}
