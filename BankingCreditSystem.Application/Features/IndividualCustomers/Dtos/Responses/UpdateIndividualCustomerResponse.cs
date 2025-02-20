namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class UpdateIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime UpdatedDate { get; set; }
} 