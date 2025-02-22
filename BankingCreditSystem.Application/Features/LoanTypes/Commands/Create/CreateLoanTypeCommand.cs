using AutoMapper;
using BankingCreditSystem.Application.Features.LoanTypes.Rules;
using BankingCreditSystem.Application.Features.LoanTypes.Dtos.Requests;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;

namespace BankingCreditSystem.Application.Features.LoanTypes.Commands.Create;

public class CreateLoanTypeCommand : IRequest<GetLoanTypeResponse>
{
    public CreateLoanTypeRequest Request { get; set; } = default!;

    public class CreateLoanTypeCommandHandler : IRequestHandler<CreateLoanTypeCommand, GetLoanTypeResponse>
    {
        private readonly ILoanTypeRepository _loanTypeRepository;
        private readonly IMapper _mapper;
        private readonly LoanTypeBusinessRules _businessRules;

        public CreateLoanTypeCommandHandler(
            ILoanTypeRepository loanTypeRepository,
            IMapper mapper,
            LoanTypeBusinessRules businessRules)
        {
            _loanTypeRepository = loanTypeRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetLoanTypeResponse> Handle(CreateLoanTypeCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.LoanTypeNameCannotBeDuplicated(request.Request.Name);
            _businessRules.ValidateAmountRange(request.Request.MinAmount, request.Request.MaxAmount);
            _businessRules.ValidateTermRange(request.Request.MinTerm, request.Request.MaxTerm);

            if (request.Request.ParentLoanTypeId.HasValue)
            {
                await _businessRules.LoanTypeShouldExistWhenSelected(request.Request.ParentLoanTypeId.Value);
            }

            var loanType = _mapper.Map<LoanType>(request.Request);
            loanType.IsActive = true;

            await _loanTypeRepository.AddAsync(loanType, cancellationToken);
            return _mapper.Map<GetLoanTypeResponse>(loanType);
        }
    }
} 