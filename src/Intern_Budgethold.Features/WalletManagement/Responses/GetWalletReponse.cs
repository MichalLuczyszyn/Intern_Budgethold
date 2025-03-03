namespace Intern_Budgethold.Features.WalletManagement.Responses;

public sealed record GetWalletResponse(
  Guid Id,
  string Name,
  DateTime CreatedAt
);
