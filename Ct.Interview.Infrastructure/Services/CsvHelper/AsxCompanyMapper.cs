using CsvHelper.Configuration;
using Ct.Interview.Domain.Entities;

namespace Ct.Interview.Infrastructure.Services.CsvHelper
{
    public class AsxCompanyMapper : ClassMap<AsxCompany>
    {
        public AsxCompanyMapper()
        {
            Map(a => a.CompanyName).Index(0);
            Map(a => a.AsxCode).Index(1);
            Map(a => a.GicsIndustryGroup).Index(2);
        }
    }
}
