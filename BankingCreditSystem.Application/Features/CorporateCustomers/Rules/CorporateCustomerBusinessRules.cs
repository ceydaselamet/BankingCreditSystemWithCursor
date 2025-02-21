using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Rules;

public class CorporateCustomerBusinessRules
{
    private readonly ICorporateCustomerRepository _corporateCustomerRepository;

    public CorporateCustomerBusinessRules(ICorporateCustomerRepository corporateCustomerRepository)
    {
        _corporateCustomerRepository = corporateCustomerRepository;
    }

    public async Task CustomerShouldExistWhenSelected(Guid id)
    {
        var customer = await _corporateCustomerRepository.GetAsync(id);
        if (customer == null) 
            throw new BusinessException(CorporateCustomerMessages.CustomerNotFound);
    }

    public async Task TaxNumberCannotBeDuplicated(string taxNumber)
    {
        var result = await _corporateCustomerRepository.AnyAsync(c => c.TaxNumber == taxNumber);
        if (result) 
            throw new BusinessException(CorporateCustomerMessages.TaxNumberAlreadyExists);
    }

    public async Task CompanyRegistrationNumberCannotBeDuplicated(string registrationNumber)
    {
        var result = await _corporateCustomerRepository.AnyAsync(c => c.CompanyRegistrationNumber == registrationNumber);
        if (result) 
            throw new BusinessException(CorporateCustomerMessages.RegistrationNumberAlreadyExists);
    }
} 