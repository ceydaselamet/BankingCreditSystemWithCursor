using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Persistence.Contexts;

public class BankingCreditSystemDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    public BankingCreditSystemDbContext(DbContextOptions<BankingCreditSystemDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
} 