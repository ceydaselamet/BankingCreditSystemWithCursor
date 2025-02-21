using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Domain.Entities;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, CreateIndividualCustomerResponse>();
        
        CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerResponse>();
        
        CreateMap<IndividualCustomer, GetIndividualCustomerResponse>();
        CreateMap<IndividualCustomer, GetIndividualCustomerListResponse>();
        
        CreateMap<IPaginate<IndividualCustomer>, IPaginate<GetIndividualCustomerListResponse>>()
            .ConvertUsing((src, dest, context) =>
            {
                var items = context.Mapper.Map<IList<GetIndividualCustomerListResponse>>(src.Items);
                return new Paginate<GetIndividualCustomerListResponse>
                {
                    Items = items,
                    Index = src.Index,
                    Size = src.Size,
                    Count = src.Count,
                    Pages = src.Pages,
                    From = src.From
                };
            });
    }
} 