using Intern_Budgethold.Features.UserAuth;
using Microsoft.EntityFrameworkCore;

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

  public async Task<User?> GetUserByEmailAsync(string email)
  {
    return await _context.Users.FirstOrDefaultAsync(
      u => u.Email.ToUpper() == email.ToUpper());
  }

  public async Task<User?> GetUserByIdAsync(Guid id)
  {
    return await _context.Users.FindAsync(id);
  }
}
