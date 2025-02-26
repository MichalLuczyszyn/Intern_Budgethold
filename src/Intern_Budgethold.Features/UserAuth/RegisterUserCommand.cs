using MediatR;
namespace Intern_Budgethold.Features.UserAuth;

public record RegisterUserCommand(
  string Email,
  string Password,
  string FirstName,
  string LastName
) : IRequest<Guid>;
