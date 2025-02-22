using System.Reflection;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.LoanTypes.Rules;
using BankingCreditSystem.Application.Features.LoanApplications.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace BankingCreditSystem.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();
        services.AddScoped<LoanTypeBusinessRules>();
        services.AddScoped<LoanApplicationBusinessRules>();

        return services;
    }
} 