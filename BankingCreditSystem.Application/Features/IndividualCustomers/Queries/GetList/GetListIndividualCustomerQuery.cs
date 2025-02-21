using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<IPaginate<GetIndividualCustomerListResponse>>
{
    public PaginationParams? Pagination { get; set; }

    public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, IPaginate<GetIndividualCustomerListResponse>>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetListIndividualCustomerQueryHandler(
            IIndividualCustomerRepository individualCustomerRepository,
            IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetIndividualCustomerListResponse>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _individualCustomerRepository.GetListAsync(
                pagination: request.Pagination ?? new PaginationParams { PageNumber = 1, PageSize = 10 },
                cancellationToken: cancellationToken
            );

            var mappedCustomers = _mapper.Map<IPaginate<GetIndividualCustomerListResponse>>(customers);
            return mappedCustomers;
        }
    }
} 