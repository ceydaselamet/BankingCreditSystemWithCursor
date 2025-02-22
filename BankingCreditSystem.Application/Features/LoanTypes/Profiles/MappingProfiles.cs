using AutoMapper;
using BankingCreditSystem.Application.Features.LoanTypes.Dtos.Requests;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.LoanTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoanType, GetLoanTypeResponse>()
            .ForMember(dest => dest.SubTypes, 
                      opt => opt.MapFrom(src => src.SubLoanTypes));
        
        CreateMap<CreateLoanTypeRequest, LoanType>();
        CreateMap<UpdateLoanTypeRequest, LoanType>();
        
        CreateMap<IPaginate<LoanType>, IPaginate<GetLoanTypeResponse>>()
            .ConvertUsing((src, dest, context) => new Paginate<GetLoanTypeResponse>
            {
                Items = context.Mapper.Map<IList<GetLoanTypeResponse>>(src.Items),
                Index = src.Index,
                Size = src.Size,
                Count = src.Count,
                Pages = src.Pages,
                From = src.From
            });
    }
} 