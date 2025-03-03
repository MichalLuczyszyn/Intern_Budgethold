using Intern_Budgethold.Features.CategoryManagement;
using Intern_Budgethold.Features.WalletManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intern_Budgethold.Infrastructure.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Name).IsRequired().HasMaxLength(100)
      .HasConversion(
        v => v.Value,
        v => CategoryName.Create(v)
      );
    builder.Property(c => c.Type).IsRequired();

    builder.HasOne<Wallet>()
      .WithMany()
      .HasForeignKey(c => c.WalletId);

    builder.HasIndex(c => new { c.WalletId, c.Name, c.Type }).IsUnique();
  }
}
