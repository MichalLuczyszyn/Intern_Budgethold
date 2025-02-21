using MediatR;

namespace Intern_Budgethold.Features.WalletManagement;

public record UpdateWalletCommand(Guid Id, string Name) : IRequest;
