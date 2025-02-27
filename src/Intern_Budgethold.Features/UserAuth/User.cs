namespace Intern_Budgethold.Features.UserAuth;

public class User
{
  public Guid Id { get; set; }
  public string Email { get; set; } = string.Empty;
  public string PasswordHash { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}
