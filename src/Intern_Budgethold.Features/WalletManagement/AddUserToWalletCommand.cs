using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public record class AddUserToWalletCommand(Guid WalletId, Guid UserId) : IRequest;
