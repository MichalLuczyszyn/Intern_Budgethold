using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Intern_Budgethold.Features.WalletManagement;

public static class DeleteWallet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapDelete("/api/walltes/{walletId}", async ([FromRoute] Guid walletId,
      IMediator mediator) =>
    {
      var command = new DeleteWalletCommand(walletId);
      await mediator.Send(command);

      return Results.NoContent();
    })
    .WithName("DeleteWallet")
    .WithTags("Wallets");
  }
}
