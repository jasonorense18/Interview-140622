namespace Ct.Interview.Infrastructure.Services
{
    public class AsxSettings
    {
        public const string SectionName = "AsxSettings";
        public const string ClientName = "AsxCompany";
        public string ListedSecuritiesCsvUrl { get; init; } = null!;
        public string BaseUrl { get; init; } = null!;
        public string CsvHeader { get; set; } = null!;
    }
}