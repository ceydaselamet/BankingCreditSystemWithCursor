namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class GetIndividualCustomerListResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
} 