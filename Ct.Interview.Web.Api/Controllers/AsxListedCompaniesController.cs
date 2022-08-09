using Ct.Interview.Application.AsxCompany.Commands.ImportAsxCompany;
using Ct.Interview.Application.AsxCompany.Common;
using Ct.Interview.Application.AsxCompany.Queries.GetAsxCompanyByCode;
using Ct.Interview.Contracts.AsxCompany;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ct.Interview.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class AsxListedCompaniesController : ApiController
    {
        private readonly ISender _mediator;

        public AsxListedCompaniesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import()
        {
            var command = new ImportAsxCompanyCommand();
            ErrorOr<ImportAsxCommandResult> result = await _mediator.Send(command);

            return result.Match(
               authResult => Ok(),
               errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> Get(string asxCode)
        {
            var command = new GetAsxCompanyByCodeCommand(asxCode);

            ErrorOr<AsxCompanyResult> result = await _mediator.Send(command);

            return result.Match(
              res => Ok(new AsxCompanyResponse 
                { 
                    AsxCode = res.AsxCode, 
                    CompanyName = res.CompanyName 
                }),
              errors => Problem(errors));
        }
    }
}
