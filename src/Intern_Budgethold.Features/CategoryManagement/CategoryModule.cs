using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Intern_Budgethold.Features.CategoryManagement;

public static class CategoryModule
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    CreateCategory.MapEndpoint(app);
    GetCategory.MapEndpoint(app);
  }
  public static IServiceCollection AddCategoryManagement(
      this IServiceCollection services
    )
    {
    services.AddScoped<ICategoryService, CategoryService>();

    return services;
    }
}
