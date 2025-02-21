using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Features.UserAuth;
using Intern_Budgethold.Features.WalletManagement;

namespace Intern_Budgethold.Infrastructure.DataAccess;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Wallet> Wallets { get; set; }
  public DbSet<WalletUser> WalletUsers { get; set; }
}
