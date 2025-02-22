using AutoMapper;
using BankingCreditSystem.Application.Features.LoanApplications.Rules;
using BankingCreditSystem.Application.Features.LoanApplications.Dtos.Responses;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;

namespace BankingCreditSystem.Application.Features.LoanApplications.Queries.GetById;

public class GetByIdLoanApplicationQuery : IRequest<GetLoanApplicationResponse>
{
    public Guid Id { get; set; }

    public class GetByIdLoanApplicationQueryHandler : IRequestHandler<GetByIdLoanApplicationQuery, GetLoanApplicationResponse>
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IMapper _mapper;
        private readonly LoanApplicationBusinessRules _businessRules;

        public GetByIdLoanApplicationQueryHandler(
            ILoanApplicationRepository loanApplicationRepository,
            IMapper mapper,
            LoanApplicationBusinessRules businessRules)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetLoanApplicationResponse> Handle(GetByIdLoanApplicationQuery request, CancellationToken cancellationToken)
        {
            await _businessRules.LoanApplicationShouldExistWhenSelected(request.Id);
            var loanApplication = await _loanApplicationRepository.GetAsync(request.Id, cancellationToken);
            return _mapper.Map<GetLoanApplicationResponse>(loanApplication);
        }
    }
} 