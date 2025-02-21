using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;

public class GetByIdCorporateCustomerQuery : IRequest<GetCorporateCustomerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCorporateCustomerQueryHandler : IRequestHandler<GetByIdCorporateCustomerQuery, GetCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public GetByIdCorporateCustomerQueryHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper,
            CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetCorporateCustomerResponse> Handle(GetByIdCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            await _businessRules.CustomerShouldExistWhenSelected(request.Id);

            var corporateCustomer = await _corporateCustomerRepository.GetAsync(request.Id, cancellationToken);
            return _mapper.Map<GetCorporateCustomerResponse>(corporateCustomer);
        }
    }
} 