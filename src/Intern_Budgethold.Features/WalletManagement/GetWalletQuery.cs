using MediatR;
using Intern_Budgethold.Features.WalletManagement.Responses;

namespace Intern_Budgethold.Features.WalletManagement;

public record GetWalletQuery(Guid WalletId) : IRequest<GetWalletResponse>;
