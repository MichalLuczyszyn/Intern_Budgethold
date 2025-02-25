using MediatR;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intern_Budgethold.Features.WalletManagement.Responses;

namespace Intern_Budgethold.Features.WalletManagement;

public static class GetWallet
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("/api/wallets/{walletId}", async ([FromRoute] Guid walletId, IMediator mediator) =>
      {
        var query = new GetWalletQuery(walletId);
        var result = await mediator.Send(query);

        return result is null ?
            Results.NotFound() :
            Results.Ok(result);
      })
      .RequireAuthorization()
      .WithName("GetWallet")
      .WithTags("Wallets")
      .Produces<GetWalletResponse>(StatusCodes.Status200OK);
  }
}
