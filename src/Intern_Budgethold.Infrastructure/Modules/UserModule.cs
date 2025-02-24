using Intern_Budgethold.Infrastructure.DataAccess.Configurations;
using Intern_Budgethold.Infrastructure.DataAccess.Repositories;
using Intern_Budgethold.Infrastructure.DataAccess;
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
    services.AddScoped<IEntityTypeConfiguration, UserConfiguration>();

    return services;
  }
}
