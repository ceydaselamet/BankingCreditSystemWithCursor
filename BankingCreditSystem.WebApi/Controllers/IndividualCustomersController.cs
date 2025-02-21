using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;

namespace BankingCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerRequest request)
    {
        var command = new CreateIndividualCustomerCommand { Request = request };
        var response = await Mediator.Send(command);
        return Created("", response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetByIdIndividualCustomerQuery { Id = id };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetListIndividualCustomerQuery 
        { 
            Pagination = new PaginationParams 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize 
            } 
        };
        
        var response = await Mediator.Send(query);
        return Ok(response);
    }
} 