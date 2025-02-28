using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement.Exceptions;

public class UserAlreadyInWalletException : BusinessException
{
    public UserAlreadyInWalletException() : base("User is already in the wallet.")
    {
    }
}
