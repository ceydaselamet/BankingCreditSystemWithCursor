using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerResponse>
{
    public CreateCorporateCustomerRequest Request { get; set; } = default!;

    public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public CreateCorporateCustomerCommandHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper,
            CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.TaxNumberCannotBeDuplicated(request.Request.TaxNumber);
            await _businessRules.CompanyRegistrationNumberCannotBeDuplicated(request.Request.CompanyRegistrationNumber);

            var corporateCustomer = _mapper.Map<CorporateCustomer>(request.Request);
            await _corporateCustomerRepository.AddAsync(corporateCustomer, cancellationToken);

            return _mapper.Map<CreateCorporateCustomerResponse>(corporateCustomer);
        }
    }
} 