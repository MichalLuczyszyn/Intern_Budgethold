namespace Intern_Budgethold.Core.Exceptions;

public class ValidationResultException : Exception
{
  public IDictionary<string, string[]> Errors { get; }

  public ValidationResultException(IDictionary<string, string[]> errors)
  {
    Errors = errors;
  }
}
