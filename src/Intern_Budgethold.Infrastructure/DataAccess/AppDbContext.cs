using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Features.UserAuth;
using Intern_Budgethold.Features.WalletManagement;

namespace Intern_Budgethold.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
  private readonly IEnumerable<IEntityTypeConfiguration> _configurations;

  public AppDbContext(
    DbContextOptions<AppDbContext> options,
    IEnumerable<IEntityTypeConfiguration> configurations) : base(options)
  {
    _configurations = configurations;
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Wallet> Wallets { get; set; }
  public DbSet<WalletUser> WalletUsers { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    foreach (var configuration in _configurations)
    {
      configuration.Configure(modelBuilder);
    }
  }
}
