using System;
using System.Threading.Tasks;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingCreditSystem.Application.Features.LoanApplications.Rules
{
    public class LoanApplicationBusinessRules
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly ILoanTypeRepository _loanTypeRepository;

        public LoanApplicationBusinessRules(
            ILoanApplicationRepository loanApplicationRepository,
            ILoanTypeRepository loanTypeRepository)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _loanTypeRepository = loanTypeRepository;
        }

        public async Task LoanTypeShouldExist(Guid loanTypeId)
        {
            var loanType = await _loanTypeRepository.GetAsync(loanTypeId);
            if (loanType == null)
                throw new BusinessException("Loan type not found");
        }

        public async Task CheckLoanAmountLimits(Guid loanTypeId, decimal requestedAmount)
        {
            var loanType = await _loanTypeRepository.GetAsync(loanTypeId);
            if (requestedAmount < loanType!.MinAmount || requestedAmount > loanType.MaxAmount)
                throw new BusinessException($"Requested amount must be between {loanType.MinAmount} and {loanType.MaxAmount}");
        }

        public async Task CheckLoanTermLimits(Guid loanTypeId, int requestedTerm)
        {
            var loanType = await _loanTypeRepository.GetAsync(loanTypeId);
            if (requestedTerm < loanType!.MinTerm || requestedTerm > loanType.MaxTerm)
                throw new BusinessException($"Requested term must be between {loanType.MinTerm} and {loanType.MaxTerm} months");
        }

        public async Task LoanApplicationShouldExistWhenSelected(Guid id)
        {
            var loanApplication = await _loanApplicationRepository.GetAsync(id);
            if (loanApplication == null)
                throw new NotFoundException("Loan application not found.");
        }
    }
} 