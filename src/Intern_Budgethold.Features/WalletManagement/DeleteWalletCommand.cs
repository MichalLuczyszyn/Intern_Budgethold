using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public record DeleteWalletCommand(Guid WalletId) : IRequest;
