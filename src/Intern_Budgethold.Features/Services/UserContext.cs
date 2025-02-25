using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Intern_Budgethold.Features.Services;

public class UserContext : IUserContext
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  public UserContext(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
  }

  public Guid? GetUserId()
  {
    var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    return userId is not null ? Guid.Parse(userId) : null;
  }
}
