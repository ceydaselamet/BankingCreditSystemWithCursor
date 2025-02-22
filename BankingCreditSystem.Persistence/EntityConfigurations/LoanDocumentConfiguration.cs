using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingCreditSystem.Persistence.EntityConfigurations;

public class LoanDocumentConfiguration : IEntityTypeConfiguration<LoanDocument>
{
    public void Configure(EntityTypeBuilder<LoanDocument> builder)
    {
        builder.ToTable("LoanDocuments");

        builder.HasKey(ld => ld.Id);

        builder.Property(ld => ld.DocumentType)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(ld => ld.DocumentPath)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(ld => ld.DocumentName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ld => ld.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ld => ld.FileSize)
            .IsRequired();

        builder.HasOne(ld => ld.LoanApplication)
            .WithMany(la => la.Documents)
            .HasForeignKey(ld => ld.LoanApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 