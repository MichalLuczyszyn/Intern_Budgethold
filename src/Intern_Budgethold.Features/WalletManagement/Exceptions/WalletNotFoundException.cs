using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement.Exceptions;

public class WalletNotFoundException : NotFoundException
{
  public WalletNotFoundException(string message = "Wallet not found") : base(message)
  {
  }
}
