using MediatR;
using Intern_Budgethold.Features.WalletManagement.Responses;
using Intern_Budgethold.Features.WalletManagement.Exceptions;
using Intern_Budgethold.Infrastructure.DataAccess;
using Intern_Budgethold.Features.Services;
using Microsoft.EntityFrameworkCore;

namespace Intern_Budgethold.Features.WalletManagement;

public class GetWalletHandler : IRequestHandler<GetWalletQuery, GetWalletResponse>
{
  private readonly IUserContext _userContext;
  private readonly AppDbContext _dbContext;

  public GetWalletHandler(
    IUserContext userContext,
    AppDbContext dbContext
  )
  {
    _userContext = userContext;
    _dbContext = dbContext;
  }
  public async Task<GetWalletResponse> Handle(GetWalletQuery request,
    CancellationToken ct)
  {
    var userId = _userContext.GetUserId();
    if (userId is null)
      throw new UnauthorizedAccessException("User not authenticated");

    var wallet = await _dbContext.Wallets
      .AsNoTracking()
      .Where(w => w.Id == request.WalletId &&
        !w.IsDeleted &&
        w.Users.Any(wu => wu.UserId == userId && !wu.IsDeleted))
      .Select(w => new GetWalletResponse(
        w.Id,
        w.Name,
        w.CreatedAt
      ))
      .FirstOrDefaultAsync();

    if (wallet is null)
      throw new WalletNotFoundException();

    return wallet;
  }
}
