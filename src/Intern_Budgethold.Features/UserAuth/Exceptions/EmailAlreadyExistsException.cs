namespace Intern_Budgethold.Features.UserAuth.Exceptions;

public class EmailAlreadyExistsException : Exception
{
  public EmailAlreadyExistsException()
    : base("User with this email already exists.") { }
}
