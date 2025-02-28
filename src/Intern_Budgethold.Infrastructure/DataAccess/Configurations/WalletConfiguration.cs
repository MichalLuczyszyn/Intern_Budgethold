using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Intern_Budgethold.Features.WalletManagement;
using Intern_Budgethold.Features.UserAuth;

namespace Intern_Budgethold.Infrastructure.DataAccess.Configurations;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
  public void Configure(EntityTypeBuilder<Wallet> builder)
  {
    builder.HasKey(w => w.Id);

    builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(w => w.CreatedByUserId);

    builder.Navigation(w => w.Users).AutoInclude();
  }
}

public class WalletUserConfiguration : IEntityTypeConfiguration<WalletUser>
{
  public void Configure(EntityTypeBuilder<WalletUser> builder)
  {
    builder.HasKey(wu => new { wu.WalletId, wu.UserId });
            builder.HasOne<User>()
              .WithMany()
              .HasForeignKey(w => w.UserId);
            builder.HasOne<Wallet>()
              .WithMany(w => w.Users)
              .HasForeignKey(wu => wu.WalletId);
  }
}
