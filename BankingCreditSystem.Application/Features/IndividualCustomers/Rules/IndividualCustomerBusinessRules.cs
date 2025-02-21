using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Rules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerRepository _individualCustomerRepository;

    public IndividualCustomerBusinessRules(IIndividualCustomerRepository individualCustomerRepository)
    {
        _individualCustomerRepository = individualCustomerRepository;
    }

    public async Task CustomerShouldExistWhenSelected(Guid id)
    {
        var customer = await _individualCustomerRepository.GetAsync(id);
        if (customer == null) throw new BusinessException(IndividualCustomerMessages.CustomerNotFound);
    }

    public async Task NationalIdCannotBeDuplicated(string nationalId)
    {
        var result = await _individualCustomerRepository.AnyAsync(c => c.NationalId == nationalId);
        if (result) throw new BusinessException(IndividualCustomerMessages.NationalIdAlreadyExists);
    }
} 