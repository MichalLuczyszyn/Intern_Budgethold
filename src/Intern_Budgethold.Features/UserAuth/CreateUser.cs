using Microsoft.AspNetCore.Builder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Intern_Budgethold.Features.UserAuth;

public static class CreateUser
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/users/register", async ([FromBody] CreateUserRequest request, IMediator mediator) =>
    {
      var command = new CreateUserCommand(request.Email, request.Password, request.FirstName, request.LastName);

      var userId = await mediator.Send(command);

      return Results.Created($"/api/users/{userId}", userId);
    })
    .WithName("CreateUser")
    .WithTags("User");
  }

  internal sealed class CreateUserRequest
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
