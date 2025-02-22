using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Application.Features.LoanApplications.Commands.Create;
using BankingCreditSystem.Application.Features.LoanApplications.Queries.GetById;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoanApplicationRequest request)
        {
            var command = new CreateLoanApplicationCommand { Request = request };
            var response = await Mediator.Send(command);
            return Created("", response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetByIdLoanApplicationQuery { Id = id };
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
} 