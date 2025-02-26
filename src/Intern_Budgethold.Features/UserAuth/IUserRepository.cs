namespace Intern_Budgethold.Features.UserAuth;

public interface IUserRepository
{
  Task CreateAsync(User user);
  Task<User?> GetUserByEmailAsync(string email);
}
