using Ct.Interview.Application.AsxCompany.Common;
using Ct.Interview.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Ct.Interview.Domain.Common.Errors;

namespace Ct.Interview.Application.AsxCompany.Queries.GetAsxCompanyByCode
{
    public class GetAsxCompanyByCodeHandler :
        IRequestHandler<GetAsxCompanyByCodeCommand, ErrorOr<AsxCompanyResult>>
    {
        private readonly IAsxCompanyRepository _asxCompanyRepository;

        public GetAsxCompanyByCodeHandler(
            IAsxCompanyRepository asxCompanyRepository)
        {
            _asxCompanyRepository = asxCompanyRepository;
        }

        public async Task<ErrorOr<AsxCompanyResult>> Handle(
            GetAsxCompanyByCodeCommand command, 
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var company = _asxCompanyRepository.GetByCode(command.Code);

            if (company == null)
            {
                return Errors.AsxCompany.NotFound;
            }

            return new AsxCompanyResult(
                company.CompanyName, 
                company.AsxCode, 
                company.GicsIndustryGroup);
        }
    }
}
