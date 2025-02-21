using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public class UpdateWallethandler : IRequestHandler<UpdateWalletCommand>
{
  public async Task Handle(UpdateWalletCommand request, CancellationToken ct)
  {
    var wallet = new Wallet
    {
      Id = request.Id,
      Name = request.Name
    };



    return;
  }
}
