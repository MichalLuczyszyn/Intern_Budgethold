using MediatR;

namespace Intern_Budgethold.Features.UserAuth;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
{
  private readonly IUserRepository _userRepository;

  public CreateUserHandler(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

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

    await _userRepository.CreateAsync(user);

    return user.Id;
  }
}
