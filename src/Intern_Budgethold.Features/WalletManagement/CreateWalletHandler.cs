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
    var userId = Guid.NewGuid();

    var wallet = new Wallet
    {
      Id = Guid.NewGuid(),
      Name = request.Name,
      CreatedByUserId = userId,
      CreatedAt = DateTime.UtcNow,
    };

    var walletUser = new WalletUser
    {
      UserId = wallet.CreatedByUserId,
      WalletId = wallet.Id,
      JoinedAt = DateTime.UtcNow
    };

    return wallet.Id;
  }
}
