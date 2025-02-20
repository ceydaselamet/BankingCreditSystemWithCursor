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
    }
} 