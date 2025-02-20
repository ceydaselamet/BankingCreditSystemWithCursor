namespace BankingCreditSystem.Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, CreateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerCommand>().ReverseMap();
        CreateMap<CorporateCustomer, CorporateCustomerListDto>().ReverseMap();
        CreateMap<CorporateCustomer, CorporateCustomerDto>().ReverseMap();
    }
} 