using MediatR;
namespace Intern_Budgethold.Features.UserAuth;

public record CreateUserCommand(
  string Email,
  string Password,
  string FirstName,
  string LastName
) : IRequest<Guid>;
