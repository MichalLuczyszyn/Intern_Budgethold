using Intern_Budgethold.Features.CategoryManagement.Responses;
using MediatR;

namespace Intern_Budgethold.Features.CategoryManagement;

public record GetCategoryQuery(Guid WalletId, Guid CategoryId) : IRequest<GetCategoryResponse>;
