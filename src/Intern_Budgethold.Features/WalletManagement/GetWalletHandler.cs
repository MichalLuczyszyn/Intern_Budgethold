using MediatR;
using Intern_Budgethold.Features.WalletManagement.Responses;

namespace Intern_Budgethold.Features.WalletManagement;

public class GetWalletHandler : IRequestHandler<GetWalletQuery, GetWalletResponse>
{
  public async Task<GetWalletResponse> Handle(GetWalletQuery request,
    CancellationToken ct)
  {
    var wallet = new Wallet
    {
      Id = request.WalletId,
      Name = "Default Wallet",
      CreatedByUserId = Guid.NewGuid(),
      CreatedAt = DateTime.UtcNow
    };

    return new GetWalletResponse
    {
      Id = wallet.Id,
      Name = wallet.Name,
      CreatedAt = wallet.CreatedAt,
    };
  }
}
