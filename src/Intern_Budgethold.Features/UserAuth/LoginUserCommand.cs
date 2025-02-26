using MediatR;
namespace Intern_Budgethold.Features.UserAuth;

public record LoginUserCommand(string Email, string Password) : IRequest<LoginResult>;
