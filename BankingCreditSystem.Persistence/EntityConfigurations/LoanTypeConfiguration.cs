using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class LoanTypeConfiguration : IEntityTypeConfiguration<LoanType>
{
    public void Configure(EntityTypeBuilder<LoanType> builder)
    {
        builder.ToTable("LoanTypes");

        builder.HasKey(lt => lt.Id);

        builder.Property(lt => lt.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(lt => lt.Description)
            .HasMaxLength(500);

        builder.Property(lt => lt.CustomerType)
            .IsRequired();

        builder.Property(lt => lt.MinAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(lt => lt.MaxAmount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(lt => lt.BaseInterestRate)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(lt => lt.IsActive)
            .HasDefaultValue(true);

        builder.HasOne(lt => lt.ParentLoanType)
            .WithMany(lt => lt.SubLoanTypes)
            .HasForeignKey(lt => lt.ParentLoanTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 