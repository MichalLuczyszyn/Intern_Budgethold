using MediatR;
using Intern_Budgethold.Features.Services;

namespace Intern_Budgethold.Features.WalletManagement;

public class CreateWalletHandler : IRequestHandler<CreateWalletCommand, Guid>
{
  private readonly IWalletRepository _walletRepository;
  private readonly IUserContext _userContext;

  public CreateWalletHandler(IWalletRepository walletRepository, IUserContext userContext)
  {
    _walletRepository = walletRepository;
    _userContext = userContext;
  }

  public async Task<Guid> Handle(CreateWalletCommand request,
    CancellationToken ct)
  {
    var userId = _userContext.GetUserId();
    if (userId is null)
      throw new UnauthorizedAccessException("User not authenticated");

    var wallet = Wallet.Create(
        request.Name,
        (Guid)userId,
        DateTime.UtcNow
      );

    var walletUser = new WalletUser
    (
      wallet.CreatedByUserId,
      wallet.Id
    );

    await _walletRepository.AddAsync(wallet, walletUser);

    return wallet.Id;
  }
}
