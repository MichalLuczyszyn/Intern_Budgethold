using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.CategoryManagement;

public class CategoryAlreadyExistsException : BusinessException
{
  public CategoryAlreadyExistsException() :
    base("Category already exists in this wallet.")
  {
  }
}
