namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class IndividualCustomerConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable("IndividualCustomers");

        builder.Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.NationalId)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(c => c.EmploymentStatus)
            .HasMaxLength(50);

        builder.Property(c => c.MonthlyIncome)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasIndex(c => c.NationalId)
            .IsUnique();
    }
} 