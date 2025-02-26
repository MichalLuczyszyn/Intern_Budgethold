using MediatR;
using Intern_Budgethold.Features.Services;
using Intern_Budgethold.Features.UserAuth.Exceptions;

namespace Intern_Budgethold.Features.UserAuth;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Guid>
{
  private readonly IUserRepository _userRepository;
  private readonly IPasswordHasher _passwordHasher;

  public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
  {
    _userRepository = userRepository;
    _passwordHasher = passwordHasher;
  }

  public async Task<Guid> Handle(RegisterUserCommand request,
    CancellationToken ct)
  {
    var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
    if (existingUser is not null)
      throw new EmailAlreadyExistsException();

    var user = new User
    {
      Id = Guid.NewGuid(),
      Email = request.Email,
      PasswordHash = _passwordHasher.HashPassword(request.Password),
      FirstName = request.FirstName,
      LastName = request.LastName,
      CreatedAt = DateTime.UtcNow
    };

    await _userRepository.CreateAsync(user);

    return user.Id;
  }
}
