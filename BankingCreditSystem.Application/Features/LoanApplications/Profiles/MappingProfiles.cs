using AutoMapper;
using BankingCreditSystem.Application.Features.LoanApplications.Dtos.Responses;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.LoanApplications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoanApplication, CreateLoanApplicationResponse>();
        CreateMap<LoanApplication, GetLoanApplicationResponse>()
            .ForMember(dest => dest.CustomerName, 
                      opt => opt.MapFrom(src => src.Customer.GetType() == typeof(IndividualCustomer)
                          ? $"{((IndividualCustomer)src.Customer).FirstName} {((IndividualCustomer)src.Customer).LastName}"
                          : ((CorporateCustomer)src.Customer).CompanyName))
            .ForMember(dest => dest.LoanTypeName, 
                      opt => opt.MapFrom(src => src.LoanType.Name));

        CreateMap<IPaginate<LoanApplication>, IPaginate<GetLoanApplicationResponse>>()
            .ConvertUsing((src, dest, context) => new Paginate<GetLoanApplicationResponse>
            {
                Items = context.Mapper.Map<IList<GetLoanApplicationResponse>>(src.Items),
                Index = src.Index,
                Size = src.Size,
                Count = src.Count,
                Pages = src.Pages,
                From = src.From
            });
    }
} 