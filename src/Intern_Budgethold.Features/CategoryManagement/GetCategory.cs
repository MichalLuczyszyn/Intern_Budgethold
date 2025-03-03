using Intern_Budgethold.Features.CategoryManagement.Responses;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Intern_Budgethold.Features.CategoryManagement;

public static class GetCategory
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapGet("/api/wallets/{walletId}/categories/{categoryId}", async (
    [FromRoute] Guid walletId,
    [FromRoute] Guid categoryId,
    IMediator mediator
    ) =>
    {
      var query = new GetCategoryQuery(walletId, categoryId);
      var result = await mediator.Send(query);

      return Results.Ok(result);
    })
    .RequireAuthorization()
    .WithName("GetCategory")
    .WithTags("Categories")
    .Produces<GetCategoryResponse>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);
  }
}
