using MediatR;
using Intern_Budgethold.Features.WalletManagement.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement;

public class UpdateWallethandler : IRequestHandler<UpdateWalletCommand>
{
  private readonly IWalletRepository _walletRepository;

  public UpdateWallethandler(IWalletRepository walletRepository)
  {
    _walletRepository = walletRepository;
  }

  public async Task Handle(UpdateWalletCommand request, CancellationToken ct)
  {
    var wallet = await _walletRepository.GetByIdAsync(request.Id);

    if (wallet is null)
      throw new WalletNotFoundException();

    wallet.Name = request.Name;

    await _walletRepository.UpdateAsync(wallet);
  }
}
