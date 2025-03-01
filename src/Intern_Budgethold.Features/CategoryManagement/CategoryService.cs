using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.CategoryManagement;

public interface ICategoryService
{
  Task<bool> IsCategoryUnique(Guid walletId, string name, CategoryType type);
}

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _categoryRepository;

  public CategoryService(ICategoryRepository categoryRepository)
  {
    _categoryRepository = categoryRepository;
  }

  public async Task<bool> IsCategoryUnique(Guid walletId, string name, CategoryType type)
  {
    return !(await _categoryRepository.ExistsAsync(walletId, name, type));
  }
}
