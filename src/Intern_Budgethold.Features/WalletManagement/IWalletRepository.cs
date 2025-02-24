namespace Intern_Budgethold.Features.WalletManagement;

public interface IWalletRepository
{
  Task AddAsync(Wallet wallet, WalletUser walletUser);
  Task<Wallet?> GetByIdAsync(Guid id);
  Task UpdateAsync(Wallet wallet);
  Task DeleteAsync(Wallet wallet);
}
