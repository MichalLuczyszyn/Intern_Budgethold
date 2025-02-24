using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Features.UserAuth;
namespace Intern_Budgethold.Infrastructure.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration
{
  public void Configure(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>(builder =>
      {
        builder.HasKey(u => u.Id);
      });
  }
}
