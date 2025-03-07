using MediatR;
using Intern_Budgethold.Features.WalletManagement.Responses;
using Intern_Budgethold.Features.WalletManagement.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement;

public class GetWalletHandler : IRequestHandler<GetWalletQuery, GetWalletResponse>
{
  private readonly IWalletRepository _walletRepository;

  public GetWalletHandler(IWalletRepository walletRepository)
  {
    _walletRepository = walletRepository;
  }
  public async Task<GetWalletResponse> Handle(GetWalletQuery request,
    CancellationToken ct)
  {
    var wallet = await _walletRepository.GetByIdAsync(request.WalletId);

    if (wallet is null)
      throw new WalletNotFoundException();

    return new GetWalletResponse
    {
      Id = wallet.Id,
      Name = wallet.Name,
      CreatedAt = wallet.CreatedAt,
    };
  }
}
