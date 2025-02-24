using Intern_Budgethold.Infrastructure.DataAccess.Repositories;
using Intern_Budgethold.Features.WalletManagement;
using Microsoft.Extensions.DependencyInjection;
namespace Intern_Budgethold.Infrastructure.Modules;

public static class WalletModuleInfrastructure
{
  public static IServiceCollection AddWalletInfrastructure(
    this IServiceCollection services
  )
  {
    services.AddScoped<IWalletRepository, WalletRepository>();

    return services;
  }
}
