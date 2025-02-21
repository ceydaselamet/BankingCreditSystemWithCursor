using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCorporateCustomerRequest, CorporateCustomer>();
        CreateMap<CorporateCustomer, CreateCorporateCustomerResponse>();
        
        CreateMap<UpdateCorporateCustomerRequest, CorporateCustomer>();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerResponse>();
        
        CreateMap<CorporateCustomer, GetCorporateCustomerResponse>();
        CreateMap<CorporateCustomer, GetCorporateCustomerListResponse>();
    }
} 