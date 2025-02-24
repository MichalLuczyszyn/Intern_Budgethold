using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, Guid>
{
  private readonly IWalletRepository _walletRepository;

  public CreateWalletHandler(IWalletRepository walletRepository)
  {
    _walletRepository = walletRepository;
  }

  public async Task<Guid> Handle(CreateWalletCommand request,
    CancellationToken ct)
  {
    var wallet = new Wallet
    {
      Id = Guid.NewGuid(),
      Name = request.Name,
      CreatedByUserId = request.UserId,
      CreatedAt = DateTime.UtcNow,
    };

    var walletUser = new WalletUser
    {
      UserId = wallet.CreatedByUserId,
      WalletId = wallet.Id,
      JoinedAt = DateTime.UtcNow
    };

    await _walletRepository.AddAsync(wallet, walletUser);

    return wallet.Id;
  }
}
