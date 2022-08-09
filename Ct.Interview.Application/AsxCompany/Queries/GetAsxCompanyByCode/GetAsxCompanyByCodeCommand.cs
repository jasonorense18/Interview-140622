using Ct.Interview.Application.AsxCompany.Common;
using ErrorOr;
using MediatR;

namespace Ct.Interview.Application.AsxCompany.Queries.GetAsxCompanyByCode
{
    public record GetAsxCompanyByCodeCommand(string Code) :
        IRequest<ErrorOr<AsxCompanyResult>>;
}
