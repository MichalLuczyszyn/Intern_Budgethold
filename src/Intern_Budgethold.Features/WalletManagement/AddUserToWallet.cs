using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Intern_Budgethold.Features.WalletManagement;

public static class AddUserToWallet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/wallets/{walletId}/users", async ([FromRoute] Guid walletId,
      [FromBody] AddUserToWalletRequest request, IMediator mediator) =>
    {
      var command = new AddUserToWalletCommand(walletId, request.UserId);
      await mediator.Send(command);

      return Results.NoContent();
    })
    .RequireAuthorization()
    .WithName("AddUserToWallet")
    .WithTags("Wallets")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status400BadRequest)
    .Produces(StatusCodes.Status404NotFound)
    .Produces(StatusCodes.Status422UnprocessableEntity);
  }

  internal sealed class AddUserToWalletRequest
  {
    public Guid UserId { get; set; }
  }
}
