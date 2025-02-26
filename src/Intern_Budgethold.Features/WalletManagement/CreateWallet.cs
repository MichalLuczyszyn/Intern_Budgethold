using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public static class CreateWallet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/wallets", async ([FromBody] CreateWalletRequest request, IMediator mediator) =>
      {
        var command = new CreateWalletCommand(
        request.Name
        );

        var walletId = await mediator.Send(command);

        return Results.Created($"/api/wallets/{walletId}", walletId);
      })
      .RequireAuthorization()
      .WithName("CreateWallet")
      .WithTags("Wallets")
      .Produces(StatusCodes.Status201Created);
  }

  internal sealed class CreateWalletRequest
  {
    public string Name { get; set; } = string.Empty;
  }
}
