using Intern_Budgethold.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Intern_Budgethold.Features.CategoryManagement;

public static class CreateCategory
{
  public static void MapEndpoint(IEndpointRouteBuilder app)
  {
    app.MapPost("/api/wallets/{walletId}/categories", async (
      [FromRoute] Guid walletId,
      [FromBody] CreateCategoryRequest request,
      IMediator mediator
    ) =>
    {
      var command = new CreateCategoryCommand(
        walletId,
        request.Name,
        request.Description,
        request.Type
      );

      var categoryId = await mediator.Send(command);
      return Results.Created($"/api/wallets/{walletId}/categories/{categoryId}",
        categoryId);
    })
    .RequireAuthorization()
    .WithName("CreateCategory")
    .WithTags("Categories")
    .Produces<Guid>(StatusCodes.Status201Created)
    .ProducesValidationProblem()
    .ProducesProblem(StatusCodes.Status422UnprocessableEntity)
    .ProducesProblem(StatusCodes.Status404NotFound);
  }

  internal sealed class CreateCategoryRequest
  {
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public CategoryType Type { get; set; }
  }
}
