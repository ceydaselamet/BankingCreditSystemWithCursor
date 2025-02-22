using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;
using System;

public class LoanDocument : Entity<Guid>
{
    public Guid LoanApplicationId { get; set; }
    public string DocumentType { get; set; } = default!;
    public string DocumentPath { get; set; } = default!;
    public string DocumentName { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public long FileSize { get; set; }

    // Navigation Property
    public virtual LoanApplication LoanApplication { get; set; } = default!;
} 