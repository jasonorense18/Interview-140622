using Ct.Interview.Application.Common.Interfaces.Persistence;
using Ct.Interview.Domain.Entities;

namespace Ct.Interview.Infrastructure.Persistence.InMemory
{
    public class AsxCompanyInMemoryRepository : IAsxCompanyRepository
    {
        private static readonly List<AsxCompany> _asxCompany = new();

        public void AddRange(List<AsxCompany> asxCompanies)
        {
            _asxCompany.AddRange(asxCompanies);
        }

        public AsxCompany? GetByCode(string code)
        {
            var company = _asxCompany.FirstOrDefault(a => a.AsxCode == code);
            return company;
        }
    }
}
