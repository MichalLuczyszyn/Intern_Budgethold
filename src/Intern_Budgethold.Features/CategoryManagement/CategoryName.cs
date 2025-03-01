using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.CategoryManagement;

public sealed record CategoryName
{
  public string Value { get; }

  private CategoryName(string value)
  {
    Value = value;
  }

  public static CategoryName Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      throw new BusinessException("Category name cannot be empty");

    return new CategoryName(value);
  }

  public static implicit operator string(CategoryName categoryName) =>
    categoryName.Value;

  public static implicit operator CategoryName(string value) => Create(value);
}
