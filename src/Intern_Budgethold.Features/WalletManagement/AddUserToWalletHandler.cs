using Intern_Budgethold.Features.UserAuth;
using Intern_Budgethold.Features.UserAuth.Exceptions;
using Intern_Budgethold.Features.WalletManagement.Exceptions;
using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public class AddUserToWalletHandler : IRequestHandler<AddUserToWalletCommand>
{
  private readonly IWalletRepository _walletRepository;
  private readonly IUserRepository _userRepository;

  public AddUserToWalletHandler(IWalletRepository walletRepository, IUserRepository userRepository)
  {
    _walletRepository = walletRepository;
    _userRepository = userRepository;
  }

  public async Task Handle(AddUserToWalletCommand request, CancellationToken ct)
  {
    var wallet = await _walletRepository.GetByIdAsync(request.WalletId);
    if (wallet is null)
      throw new WalletNotFoundException();

    var user = await _userRepository.GetUserByIdAsync(request.UserId);

    if (user is null)
      throw new UserNotFoundException();

    wallet.AddUser(user.Id);

    await _walletRepository.UpdateAsync(wallet);
  }
}
