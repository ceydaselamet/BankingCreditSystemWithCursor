using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class LoanApplicationConfiguration : IEntityTypeConfiguration<LoanApplication>
{
    public void Configure(EntityTypeBuilder<LoanApplication> builder)
    {
        builder.ToTable("LoanApplications");

        builder.HasKey(la => la.Id);

        builder.Property(la => la.RequestedAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(la => la.RequestedTerm)
            .IsRequired();

        builder.Property(la => la.InterestRate)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(la => la.MonthlyPayment)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(la => la.TotalPayment)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(la => la.Status)
            .IsRequired();

        builder.Property(la => la.RejectionReason)
            .HasMaxLength(500);

        builder.HasOne(la => la.Customer)
            .WithMany()
            .HasForeignKey(la => la.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(la => la.LoanType)
            .WithMany(lt => lt.LoanApplications)
            .HasForeignKey(la => la.LoanTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 