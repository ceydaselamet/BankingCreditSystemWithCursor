using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;


namespace BankingCreditSystem.Application.Features.LoanTypes.Queries.GetList
{
    public class GetListLoanTypeQuery : IRequest<IPaginate<GetLoanTypeResponse>>
    {
        public CustomerType? CustomerType { get; set; }
        public PaginationParams? Pagination { get; set; }

        public class GetListLoanTypeQueryHandler : IRequestHandler<GetListLoanTypeQuery, IPaginate<GetLoanTypeResponse>>
        {
            private readonly ILoanTypeRepository _loanTypeRepository;
            private readonly IMapper _mapper;

            public GetListLoanTypeQueryHandler(ILoanTypeRepository loanTypeRepository, IMapper mapper)
            {
                _loanTypeRepository = loanTypeRepository;
                _mapper = mapper;
            }

            public async Task<IPaginate<GetLoanTypeResponse>> Handle(GetListLoanTypeQuery request, CancellationToken cancellationToken)
            {
                var loanTypes = await _loanTypeRepository.GetListAsync(
                    predicate: lt => !lt.ParentLoanTypeId.HasValue && 
                                    (!request.CustomerType.HasValue || lt.CustomerType == request.CustomerType),
                    include: lt => lt.Include(x => x.SubLoanTypes),
                    pagination: request.Pagination ?? new PaginationParams { PageNumber = 1, PageSize = 10 },
                    cancellationToken: cancellationToken
                );

                return _mapper.Map<IPaginate<GetLoanTypeResponse>>(loanTypes);
            }
        }
    }
} 