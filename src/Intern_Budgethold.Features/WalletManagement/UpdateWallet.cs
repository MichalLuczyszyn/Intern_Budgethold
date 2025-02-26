using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Intern_Budgethold.Features.WalletManagement.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement;

public static class UpdateWallet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPut("/api/wallets/{walletId}", async ([FromRoute] Guid walletId,
      [FromBody] UpdateWalletRequest request,
      IMediator mediator) =>
    {
      var command = new UpdateWalletCommand(walletId, request.Name);
      await mediator.Send(command);

      return Results.NoContent();
    })
    .RequireAuthorization()
    .WithName("UpdateWallet")
    .WithTags("Wallets")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status404NotFound)
    .ProducesValidationProblem();
  }


  internal sealed class UpdateWalletRequest
  {
    public string Name { get; set; } = string.Empty;
  }
}
