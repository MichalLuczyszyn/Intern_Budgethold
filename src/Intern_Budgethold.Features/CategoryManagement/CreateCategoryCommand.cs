using Intern_Budgethold.Core.Enums;
using MediatR;

namespace Intern_Budgethold.Features.CategoryManagement;

public record CreateCategoryCommand(
  Guid WalletId,
  CategoryName Name,
  string? Description,
  CategoryType Type
) : IRequest<Guid>;
