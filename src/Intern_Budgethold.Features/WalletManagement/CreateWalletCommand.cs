using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public record CreateWalletCommand(
  string Name,
  Guid UserId
) : IRequest<Guid>;
