using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.CategoryManagement;

public interface ICategoryRepository
{
  Task AddAsync(Category category);
  Task<bool> ExistsAsync(Guid walletId, string name, CategoryType type);
  Task<Category?> GetByIdAsync(Guid id, Guid walletId);
}
