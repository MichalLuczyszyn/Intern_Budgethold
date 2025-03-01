using Intern_Budgethold.Core.Enums;
using MediatR;

namespace Intern_Budgethold.Features.CategoryManagement;

public record UpdateCategoryCommand(
  Guid WalletId,
  Guid CategoryId,
  CategoryName Name,
  string? Description,
  CategoryType Type
) : IRequest;
