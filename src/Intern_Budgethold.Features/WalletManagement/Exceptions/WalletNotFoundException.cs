namespace Intern_Budgethold.Features.WalletManagement.Exceptions;

public class WalletNotFoundException : Exception
{
  public WalletNotFoundException(string message = "Wallet not found") : base(message)
  {
  }
}
