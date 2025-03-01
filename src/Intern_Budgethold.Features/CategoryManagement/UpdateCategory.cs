using Intern_Budgethold.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Intern_Budgethold.Features.CategoryManagement;

public static class UpdateCategory
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPut("/api/wallets/{walletId}/categories/{categoryId}", async (
    [FromRoute] Guid walletId,
    [FromRoute] Guid categoryId,
    [FromBody] UpdateCategoryRequest request,
    IMediator mediator
    ) =>
    {
      var command = new UpdateCategoryCommand(
        walletId,
        categoryId,
        request.Name,
        request.Description,
        request.Type
      );

      await mediator.Send(command);
      return Results.NoContent();
    })
    .RequireAuthorization()
    .WithName("UpdateCategory")
    .WithTags("Categories")
    .Produces(StatusCodes.Status204NoContent)
    .ProducesValidationProblem()
    .ProducesProblem(StatusCodes.Status404NotFound)
    .ProducesProblem(StatusCodes.Status422UnprocessableEntity);
  }

  internal sealed class UpdateCategoryRequest
  {
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public CategoryType Type { get; set; }
  }
}
