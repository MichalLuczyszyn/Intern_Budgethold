using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Features.WalletManagement;
using Intern_Budgethold.Features.UserAuth;

namespace Intern_Budgethold.Infrastructure.DataAccess.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration
{
  public void Configure(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Wallet>(builder =>
      {
        builder.HasKey(w => w.Id);
        builder.HasOne<User>()
          .WithMany()
          .HasForeignKey(w => w.CreatedByUserId);
      });

    modelBuilder.Entity<WalletUser>(builder =>
      {
        builder.HasKey(wu => new { wu.WalletId, wu.UserId });
        builder.HasOne<User>()
          .WithMany()
          .HasForeignKey(w => w.UserId);
        builder.HasOne<Wallet>()
          .WithMany()
          .HasForeignKey(wu => wu.WalletId);
      });
  }
}
