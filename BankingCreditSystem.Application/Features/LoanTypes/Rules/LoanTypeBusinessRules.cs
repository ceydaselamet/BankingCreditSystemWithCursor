using BankingCreditSystem.Application.Features.LoanTypes.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingCreditSystem.Application.Features.LoanTypes.Rules;

public class LoanTypeBusinessRules
{
    private readonly ILoanTypeRepository _loanTypeRepository;

    public LoanTypeBusinessRules(ILoanTypeRepository loanTypeRepository)
    {
        _loanTypeRepository = loanTypeRepository;
    }

    public async Task LoanTypeShouldExistWhenSelected(Guid id)
    {
        var loanType = await _loanTypeRepository.GetAsync(id);
        if (loanType == null) 
            throw new BusinessException(LoanTypeMessages.LoanTypeNotFound);
    }

    public async Task LoanTypeNameCannotBeDuplicated(string name)
    {
        var result = await _loanTypeRepository.AnyAsync(lt => lt.Name == name);
        if (result) 
            throw new BusinessException(LoanTypeMessages.LoanTypeAlreadyExists);
    }

    public void ValidateAmountRange(decimal minAmount, decimal maxAmount)
    {
        if (maxAmount <= minAmount)
            throw new BusinessException(LoanTypeMessages.InvalidAmountRange);
    }

    public void ValidateTermRange(int minTerm, int maxTerm)
    {
        if (maxTerm <= minTerm)
            throw new BusinessException(LoanTypeMessages.InvalidTermRange);
    }
} 