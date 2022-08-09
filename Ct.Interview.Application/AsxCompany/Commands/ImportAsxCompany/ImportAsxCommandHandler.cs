using Ct.Interview.Application.Common.Interfaces.Persistence;
using Ct.Interview.Application.Common.Interfaces.Services;
using ErrorOr;
using MediatR;
using Ct.Interview.Domain.Common.Errors;

namespace Ct.Interview.Application.AsxCompany.Commands.ImportAsxCompany
{
    public class ImportAsxCommandHandler :
        IRequestHandler<ImportAsxCompanyCommand, ErrorOr<ImportAsxCommandResult>>
    {
        private readonly IHttpService _httpService;
        private readonly IAsxCompanyRepository _asxCompanyRepository;
        private readonly ICsvHelperService _csvHelperService;

        public ImportAsxCommandHandler(
            IHttpService httpService,
            IAsxCompanyRepository asxCompanyRepository,
            ICsvHelperService csvHelperService)
        {
            _httpService = httpService;
            _asxCompanyRepository = asxCompanyRepository;
            _csvHelperService = csvHelperService;
        }

        public async Task<ErrorOr<ImportAsxCommandResult>> Handle(ImportAsxCompanyCommand command, CancellationToken cancellationToken)
        {
            Stream? stream = await _httpService.GetCompanyDetailsFromUrl();

            if (stream == null)
            {
                return Errors.AsxCompany.FileNotFound;
            }

            var result = _csvHelperService.GetAsxCompanyList(stream);

            _asxCompanyRepository.AddRange(result);

            return new ImportAsxCommandResult();
        }
    }
}