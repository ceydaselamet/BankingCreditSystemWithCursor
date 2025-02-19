namespace BankingCreditSystem.Domain.Entities;

public class IndividualCustomer : Customer
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalId { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string? EmploymentStatus { get; set; }
    public decimal MonthlyIncome { get; set; }
} 