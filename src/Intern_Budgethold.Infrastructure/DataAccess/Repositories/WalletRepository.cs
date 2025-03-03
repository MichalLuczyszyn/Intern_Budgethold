using Microsoft.EntityFrameworkCore;
using Intern_Budgethold.Features.WalletManagement;

namespace Intern_Budgethold.Infrastructure.DataAccess.Repositories;

public class WalletRepository : IWalletRepository
{
  private readonly AppDbContext _context;

  public WalletRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task AddAsync(Wallet wallet, WalletUser walletUser)
  {
    await _context.Wallets.AddAsync(wallet);
    await _context.WalletUsers.AddAsync(walletUser);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(Wallet wallet)
  {
    using (var transaction = await _context.Database.BeginTransactionAsync())
    {
      try
      {
        _context.Wallets.Update(wallet);
        var walletUsers = await _context.WalletUsers
          .Where(wu => wu.WalletId == wallet.Id && !wu.IsDeleted)
          .ToListAsync();

        foreach (var walletUser in walletUsers)
        {
          walletUser.IsDeleted = true;
        }
        _context.WalletUsers.UpdateRange(walletUsers);

        var categories = await _context.Categories
          .Where(c => c.WalletId == wallet.Id && !c.IsDeleted)
          .ToListAsync();

        foreach (var category in categories)
        {
          category.SoftDelete();
        }
        _context.Categories.UpdateRange(categories);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
      }
      catch
      {
        await transaction.RollbackAsync();
      }
    }
  }

  public async Task<Wallet?> GetByIdAsync(Guid id)
  {
    return await _context.Wallets
      .Include(w => w.Users)
      .FirstOrDefaultAsync(w => w.Id == id && w.IsDeleted == false);
  }

  public async Task UpdateAsync(Wallet wallet)
  {
    _context.Wallets.Update(wallet);
    await _context.SaveChangesAsync();
  }
}
