using Intern_Budgethold.Core.Exceptions;

namespace Intern_Budgethold.Features.UserAuth.Exceptions;

public class EmailAlreadyExistsException : BusinessException
{
  public EmailAlreadyExistsException()
    : base("User with this email already exists.") { }
}
