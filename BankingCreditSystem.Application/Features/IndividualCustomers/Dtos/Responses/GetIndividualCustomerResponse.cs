namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;

public class GetIndividualCustomerResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? EmploymentStatus { get; set; }
    public decimal MonthlyIncome { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
} 