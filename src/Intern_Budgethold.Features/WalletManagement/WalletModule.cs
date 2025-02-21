using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Intern_Budgethold.Features.WalletManagement;

public static class WalletModule
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    CreateWallet.MapEndpoint(app);
    GetWallet.MapEndpoint(app);
    DeleteWallet.MapEndpoint(app);
  }

  public static IServiceCollection AddWalletModule(
    this IServiceCollection services
  )
  {
    return services;
  }
}
