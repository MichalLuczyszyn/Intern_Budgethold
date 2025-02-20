using MediatR;

namespace Intern_Budgethold.Features.UserAuth;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
  public async Task<Guid> Handle(CreateUserCommand request,
    CancellationToken ct)
  {
    var user = new User
    {
      Id = Guid.NewGuid(),
      Email = request.Email,
      PasswordHash = request.Password,
      FirstName = request.FirstName,
      LastName = request.LastName,
      CreatedAt = DateTime.UtcNow
    };


    return user.Id;
  }
}
