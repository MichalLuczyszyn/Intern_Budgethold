using Intern_Budgethold.Core.Enums;
using Intern_Budgethold.Features.CategoryManagement;
using Microsoft.EntityFrameworkCore;

namespace Intern_Budgethold.Infrastructure.DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private readonly AppDbContext _context;

  public CategoryRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task AddAsync(Category category)
  {
    await _context.Categories.AddAsync(category);
    await _context.SaveChangesAsync();
  }

  public async Task<bool> ExistsAsync(Guid walletId, string name, CategoryType type)
  {
    return await _context.Categories.AnyAsync(c =>
      c.WalletId == walletId &&
      c.Name == name &&
      c.Type == type
    );
  }
}
