using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement.Exceptions;

public class MaxUsersExceededException : BusinessException
{
  public MaxUsersExceededException(uint maxUsers)
    : base($"Wallet has reached the maximum number of users ({maxUsers}).")
  { }
}
