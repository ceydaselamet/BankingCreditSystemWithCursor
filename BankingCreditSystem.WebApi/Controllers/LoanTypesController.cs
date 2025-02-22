using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Application.Features.LoanTypes.Queries.GetList;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Application.Features.LoanTypes.Commands.Create;
using BankingCreditSystem.Application.Features.LoanTypes.Dtos.Requests;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] CustomerType? customerType, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetListLoanTypeQuery 
            { 
                CustomerType = customerType,
                Pagination = new PaginationParams 
                { 
                    PageNumber = pageNumber, 
                    PageSize = pageSize 
                }
            };
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLoanTypeRequest request)
        {
            var command = new CreateLoanTypeCommand { Request = request };
            var response = await Mediator.Send(command);
            return Created("", response);
        }
    }
} 