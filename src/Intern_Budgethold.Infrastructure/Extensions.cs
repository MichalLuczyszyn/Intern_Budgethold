using Microsoft.Extensions.DependencyInjection;
using Intern_Budgethold.Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Infrastructure.Modules;

namespace Intern_Budgethold.Infrastructure;

public static class Extensions
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services, IConfiguration configuration
  )
  {
    var connectionString = configuration.GetConnectionString(
      "DefaultConnection");

    services.AddDbContext<AppDbContext>(options =>
      options.UseNpgsql(connectionString));

    services.AddUserInfrastructure()
      .AddWalletInfrastructure()
      .AddCategoryInfrastructure();

    return services;
  }
}
