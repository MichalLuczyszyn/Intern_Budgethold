using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Intern_Budgethold.Features.WalletManagement.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement;

public static class DeleteWallet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapDelete("/api/wallets/{walletId}", async ([FromRoute] Guid walletId,
      IMediator mediator) =>
    {
      var command = new DeleteWalletCommand(walletId);
      await mediator.Send(command);

      return Results.NoContent();
    })
    .RequireAuthorization()
    .WithName("DeleteWallet")
    .WithTags("Wallets")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status404NotFound);
  }
}
