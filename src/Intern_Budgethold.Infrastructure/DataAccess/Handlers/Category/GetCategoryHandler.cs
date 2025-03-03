using Intern_Budgethold.Features.CategoryManagement.Exceptions;
using Intern_Budgethold.Features.CategoryManagement.Responses;
using Intern_Budgethold.Features.Services;
using Intern_Budgethold.Features.WalletManagement.Exceptions;
using Intern_Budgethold.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Intern_Budgethold.Features.CategoryManagement;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, GetCategoryResponse>
{
  private readonly AppDbContext _dbContext;
  private readonly IUserContext _userContext;

  public GetCategoryHandler(
    AppDbContext dbContext,
    IUserContext userContext
  )
  {
    _dbContext = dbContext;
    _userContext = userContext;
  }

  public async Task<GetCategoryResponse> Handle(GetCategoryQuery request,
    CancellationToken ct)
  {
    var userId = _userContext.GetUserId();
    if (userId is null)
      throw new UnauthorizedAccessException("User not authenticated");

    var walletAccess = await _dbContext.WalletUsers
      .AsNoTracking()
      .AnyAsync(wu => wu.WalletId == request.WalletId &&
        wu.UserId == userId &&
        !wu.IsDeleted);

    if (!walletAccess)
      throw new WalletNotFoundException();

    var category = await _dbContext.Categories
      .AsNoTracking()
      .Where(c => c.Id == request.CategoryId &&
        c.WalletId == request.WalletId &&
        !c.IsDeleted)
      .Select(c => new GetCategoryResponse(
          c.Id,
          c.Name,
          c.Description,
          c.Type
        ))
      .FirstOrDefaultAsync();

    if (category is null)
      throw new CategoryNotFoundException();

    return category;
  }
}
