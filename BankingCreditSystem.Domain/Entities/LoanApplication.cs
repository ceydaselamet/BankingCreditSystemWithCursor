using System;
using System.Collections.Generic;
using BankingCreditSystem.Core.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Domain.Entities
{
    public class LoanApplication : Entity<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid LoanTypeId { get; set; }
        public decimal RequestedAmount { get; set; }
        public int RequestedTerm { get; set; } // Ay cinsinden
        public decimal InterestRate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public decimal TotalPayment { get; set; }
        public LoanApplicationStatus Status { get; set; }
        public string? RejectionReason { get; set; }
        
        // Navigation Properties
        public virtual Customer Customer { get; set; } = default!;
        public virtual LoanType LoanType { get; set; } = default!;
        public virtual ICollection<LoanDocument> Documents { get; set; }
    }
} 