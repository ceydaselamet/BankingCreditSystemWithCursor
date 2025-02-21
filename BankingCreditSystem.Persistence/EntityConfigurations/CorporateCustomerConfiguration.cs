using BankingCreditSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable("CorporateCustomers");

        builder.Property(c => c.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.TaxNumber)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(c => c.CompanyRegistrationNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.CompanyType)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.TradeRegistryNumber)
            .HasMaxLength(50);

        builder.Property(c => c.AnnualTurnover)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasIndex(c => c.TaxNumber)
            .IsUnique();
    }
} 