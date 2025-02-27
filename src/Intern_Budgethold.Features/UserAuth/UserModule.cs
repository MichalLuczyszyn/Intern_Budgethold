using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Intern_Budgethold.Features.Services;
using Intern_Budgethold.Features.UserAuth.Validators;
using FluentValidation;

namespace Intern_Budgethold.Features.UserAuth;

public static class UserModule
{
  public static void MapEndpoints(IEndpointRouteBuilder app)
  {
    RegisterUser.MapEndpoint(app);
    LoginUser.MapEndpoint(app);
  }

  public static IServiceCollection AddUserManagement(
    this IServiceCollection services
  )
  {
    services.AddScoped<IPasswordHasher, PasswordHasher>();
    services.AddHttpContextAccessor();
    services.AddScoped<IUserContext, UserContext>();
    services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();
    return services;
  }
}
