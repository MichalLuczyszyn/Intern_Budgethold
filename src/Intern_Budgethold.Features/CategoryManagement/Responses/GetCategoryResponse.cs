using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.CategoryManagement.Responses;

public sealed record GetCategoryResponse
(
  Guid Id,
  string Name,
  string? Description,
  CategoryType Type
);
