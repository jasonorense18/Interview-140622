using CsvHelper;
using CsvHelper.Configuration;
using Ct.Interview.Application.AsxCompany.Common;
using Ct.Interview.Application.Common.Interfaces.Services;
using Ct.Interview.Domain.Entities;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Ct.Interview.Infrastructure.Services.CsvHelper
{
    public class CsvHelperServices : ICsvHelperService
    {
        private readonly AsxSettings _asxSettings;

        private static List<string>? invalidEntries;

        public CsvHelperServices(IOptions<AsxSettings> asxSettings)
        {
            _asxSettings = asxSettings.Value;
        }

        public List<AsxCompany> GetAsxCompanyList(Stream stream)
        {
            using var reader = new StreamReader(stream);
            string? value = string.Empty;

            while (value != "Company name,ASX code,GICS industry group")
            {
                value = reader.ReadLine();
            }

            using var csv = new CsvReader(reader, CreateConfiguration());
            csv.Context.RegisterClassMap<AsxCompanyMapper>();
            var records = csv.GetRecords<AsxCompany>();
            return records.ToList();
        }

        private static CsvConfiguration CreateConfiguration()
        {
            invalidEntries = new List<string>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = false,
                BadDataFound = arg => invalidEntries.Add(arg.Context.Parser.RawRecord),
                MissingFieldFound = arg => invalidEntries.Add(arg.Context.Parser.RawRecord),
            };

            return config;
        }
    }
}
