namespace Intern_Budgethold.Features.UserAuth;

public class User
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string PasswordHash { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime CreatedAt { get; set; }
}
