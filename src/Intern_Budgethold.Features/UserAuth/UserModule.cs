using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Intern_Budgethold.Features.UserAuth;

public static class UserModule
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    CreateUser.MapEndpoint(app);
  }

  public static IServiceCollection AddUserManagement(
    this IServiceCollection services
  )
  {
    return services;
  }
}
