using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Intern_Budgethold.Features.CategoryManagement;

public class DeleteCategory
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapDelete("/api/wallets/{walletId}/categories/{categoryId}", async (
      [FromRoute] Guid walletId,
      [FromRoute] Guid categoryId,
      IMediator mediator
    ) =>
    {
      var command = new DeleteCategoryCommand(walletId, categoryId);
      await mediator.Send(command);

      return Results.NoContent();
    })
    .RequireAuthorization()
    .WithName("DeleteCategory")
    .WithTags("Categories")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status404NotFound);
  }
}
