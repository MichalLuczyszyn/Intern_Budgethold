using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.CategoryManagement;

public class Category
{
  public Guid Id { get; private set; }
  public Guid WalletId { get; private set; }
  public CategoryName Name { get; private set; } = default!;
  public string? Description { get; private set; }
  public CategoryType Type { get; private set; }
  public Guid CreatedByUserId { get; private set; }
  public DateTime CreatedAt { get; private set; }

  private Category() { }

  public static Category Create(
    Guid walletId,
    CategoryName name,
    string? description,
    CategoryType type,
    Guid createdByUserId,
    DateTime createdAt
  )
  {

    return new Category
    {
      Id = Guid.NewGuid(),
      WalletId = walletId,
      Name = name,
      Description = description,
      Type = type,
      CreatedByUserId = createdByUserId,
      CreatedAt = createdAt
    };
  }
}
