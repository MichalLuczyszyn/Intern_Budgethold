using Microsoft.EntityFrameworkCore;

namespace Intern_Budgethold.Infrastructure.DataAccess;

public interface IEntityTypeConfiguration
{
  void Configure(ModelBuilder modelBuilder);
}
