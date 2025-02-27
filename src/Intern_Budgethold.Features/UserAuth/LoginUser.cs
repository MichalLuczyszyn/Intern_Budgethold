using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Intern_Budgethold.Features.UserAuth;

public static class LoginUser
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/users/login", async ([FromBody] LoginUserRequest request,
      IMediator mediator, HttpContext httpContext) =>
        {
          var command = new LoginUserCommand(request.Email, request.Password);
          var result = await mediator.Send(command);

          if (result.IsSuccess)
          {
            httpContext.Response.Cookies.Append("jwt", result.Token, new CookieOptions
            {
              HttpOnly = true,
              Secure = false,
              SameSite = SameSiteMode.Strict,
              Expires = DateTime.UtcNow.AddDays(1)
            });
            return Results.Ok(new { message = "Login successful" });
          }
          else
          {
            return Results.Unauthorized();
          }
        })
        .WithName("LoginUser")
        .WithTags("Users")
        .Produces(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized);
  }

  public sealed class LoginUserRequest
  {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
  }
}
