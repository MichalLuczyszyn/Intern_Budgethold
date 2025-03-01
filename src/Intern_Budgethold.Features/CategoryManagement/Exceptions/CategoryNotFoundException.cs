using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.CategoryManagement.Exceptions;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException() : base("Category not found.")
    {
    }
}
