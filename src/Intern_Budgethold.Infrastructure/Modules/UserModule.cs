using Intern_Budgethold.Infrastructure.DataAccess.Repositories;
using Intern_Budgethold.Features.UserAuth;
using Microsoft.Extensions.DependencyInjection;

namespace Intern_Budgethold.Infrastructure.Modules;

public static class UserModuleInfrastructure
{
  public static IServiceCollection AddUserInfrastructure(
    this IServiceCollection services
  )
  {
    services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }
}
