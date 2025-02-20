namespace BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;

public class UpdateIndividualCustomerRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string? EmploymentStatus { get; set; }
    public decimal MonthlyIncome { get; set; }
} 