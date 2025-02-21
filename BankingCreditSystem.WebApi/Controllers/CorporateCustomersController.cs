using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCorporateCustomerRequest request)
    {
        var command = new CreateCorporateCustomerCommand { Request = request };
        var response = await Mediator.Send(command);
        return Created("", response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetByIdCorporateCustomerQuery { Id = id };
        var response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetListCorporateCustomerQuery 
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
    public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerRequest request)
    {
        var command = new UpdateCorporateCustomerCommand { Request = request };
        var response = await Mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteCorporateCustomerCommand { Id = id };
        var response = await Mediator.Send(command);
        return Ok(response);
    }
} 