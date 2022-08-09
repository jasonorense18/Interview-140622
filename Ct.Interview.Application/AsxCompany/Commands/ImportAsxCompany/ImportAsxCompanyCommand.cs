using ErrorOr;
using MediatR;

namespace Ct.Interview.Application.AsxCompany.Commands.ImportAsxCompany
{
    public record ImportAsxCompanyCommand() 
        : IRequest<ErrorOr<ImportAsxCommandResult>>;
}
