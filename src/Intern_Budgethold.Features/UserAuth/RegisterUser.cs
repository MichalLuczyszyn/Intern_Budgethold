using Microsoft.AspNetCore.Builder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using FluentValidation;

namespace Intern_Budgethold.Features.UserAuth;

public static class RegisterUser
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/users/register", async ([FromBody] RegisterUserRequest request,
      IMediator mediator) =>
    {
      var command = new RegisterUserCommand(request.Email, request.Password, request.FirstName, request.LastName);

      var userId = await mediator.Send(command);
      return Results.Created($"/api/users/{userId}", userId);
    })
    .WithName("RegisterUser")
    .WithTags("Users")
    .Produces<Guid>(StatusCodes.Status201Created)
    .ProducesValidationProblem()
    .Produces(StatusCodes.Status422UnprocessableEntity);
  }

  public sealed class RegisterUserRequest
  {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
  }
}
