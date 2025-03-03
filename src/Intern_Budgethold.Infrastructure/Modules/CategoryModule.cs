using Intern_Budgethold.Features.CategoryManagement;
using Intern_Budgethold.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Intern_Budgethold.Infrastructure.Modules;

public static class CategoryModuleInfrastructure
{
  public static IServiceCollection AddCategoryInfrastructure(this IServiceCollection services)
  {
    services.AddScoped<ICategoryRepository, CategoryRepository>();

    return services;
  }
}
