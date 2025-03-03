using MediatR;

namespace Intern_Budgethold.Features.CategoryManagement;

public record DeleteCategoryCommand(Guid WalletId, Guid CategoryId) : IRequest;
