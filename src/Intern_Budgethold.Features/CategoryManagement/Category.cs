using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.CategoryManagement;

public class Category
{
  public Guid Id { get; set; }
  public Guid WalletId { get; set; }
  public string Name { get; set; } = string.Empty;
  public string? Description { get; set; }
  public CategoryType Type { get; set; }
  public Guid CreatedByUserId { get; set; }
  public DateTime CreatedAt { get; set; }
}
