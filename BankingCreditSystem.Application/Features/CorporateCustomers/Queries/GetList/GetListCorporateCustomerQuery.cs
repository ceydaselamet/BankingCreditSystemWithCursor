using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;

public class GetListCorporateCustomerQuery : IRequest<IPaginate<GetCorporateCustomerListResponse>>
{
    public PaginationParams? Pagination { get; set; }

    public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, IPaginate<GetCorporateCustomerListResponse>>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public GetListCorporateCustomerQueryHandler(
            ICorporateCustomerRepository corporateCustomerRepository,
            IMapper mapper)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetCorporateCustomerListResponse>> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _corporateCustomerRepository.GetListAsync(
                pagination: request.Pagination ?? new PaginationParams { PageNumber = 1, PageSize = 10 },
                cancellationToken: cancellationToken
            );

            return _mapper.Map<IPaginate<GetCorporateCustomerListResponse>>(customers);
        }
    }
} 