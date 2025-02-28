using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.UserAuth.Exceptions;

public class UserNotFoundException : NotFoundException
{
  public UserNotFoundException(string message = "User not found") : base(message)
  {
  }
}
