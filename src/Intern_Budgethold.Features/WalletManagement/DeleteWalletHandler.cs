using MediatR;
using Intern_Budgethold.Features.WalletManagement.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement;

public class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand>
{
  private readonly IWalletRepository _walletRepository;

  public DeleteWalletHandler(IWalletRepository walletRepository)
  {
    _walletRepository = walletRepository;
  }

  public async Task Handle(DeleteWalletCommand request, CancellationToken ct)
  {
    var wallet = await _walletRepository.GetByIdAsync(request.WalletId);

    if (wallet is null)
      throw new WalletNotFoundException();

    wallet.IsDeleted = true;

    await _walletRepository.DeleteAsync(wallet);

    return;
  }
}
