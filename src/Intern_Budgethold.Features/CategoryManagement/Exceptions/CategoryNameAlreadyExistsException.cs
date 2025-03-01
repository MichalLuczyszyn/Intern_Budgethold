using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.CategoryManagement;

public class CategoryNameAlreadyExistsException : BusinessException
{
  public CategoryNameAlreadyExistsException() :
    base("Category name already exists in this wallet.")
  {
  }
}
