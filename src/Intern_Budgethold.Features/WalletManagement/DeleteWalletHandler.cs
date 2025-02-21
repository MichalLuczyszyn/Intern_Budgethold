using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public class DeleteWalletHandler : IRequestHandler<DeleteWalletCommand>
{
  public async Task Handle(DeleteWalletCommand request, CancellationToken ct)
  {
    var wallet = new Wallet
    {
      Id = request.WalletId
    };

    wallet.IsDeleted = true;

    return;
  }
}
