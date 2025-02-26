using Microsoft.AspNetCore.Builder;

namespace Intern_Budgethold.Api.Middleware;

public static class ExceptionHandlingMiddlewareExtensions
{
  public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
  {
    return app.UseMiddleware<ExceptionHandlingMiddleware>();
  }
}
