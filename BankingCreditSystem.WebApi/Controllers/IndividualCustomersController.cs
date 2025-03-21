using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

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
            Pagination = new Core.Repositories.PaginationParams 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize 
            } 
        };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerRequest request)
    {
        var command = new UpdateIndividualCustomerCommand { Request = request };
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteIndividualCustomerCommand { Id = id };
        var response = await Mediator.Send(command);
        return Ok(response);
    }
} 