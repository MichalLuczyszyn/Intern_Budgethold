using Intern_Budgethold.Features.UserAuth;

namespace Intern_Budgethold.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task CreateAsync(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
  }
}
