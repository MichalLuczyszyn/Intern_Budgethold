using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.CategoryManagement;

public class GetCategoryResponse
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }
  public CategoryType Type { get; set; }
}
