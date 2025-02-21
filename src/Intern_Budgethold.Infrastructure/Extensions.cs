using Microsoft.Extensions.DependencyInjection;
using Intern_Budgethold.Infrastructure.DataAccess;
using Intern_Budgethold.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Features.UserAuth;
using Intern_Budgethold.Features.WalletManagement;

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

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IWalletRepository, WalletRepository>();

    return services;
  }
}
