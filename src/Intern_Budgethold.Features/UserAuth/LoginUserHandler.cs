using MediatR;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Intern_Budgethold.Features.Services;

namespace Intern_Budgethold.Features.UserAuth;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginResult>
{
  private readonly IUserRepository _userRepository;
  private readonly IConfiguration _configuration;
  private readonly IPasswordHasher _passwordHasher;

  public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration, IPasswordHasher passwordHasher)
  {
    _userRepository = userRepository;
    _configuration = configuration;
    _passwordHasher = passwordHasher;

  }

  public async Task<LoginResult> Handle(LoginUserCommand request, CancellationToken ct)
  {
    var user = await _userRepository.GetUserByEmailAsync(request.Email);
    if (user is null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
    {
      return LoginResult.Failure("Invalid email or password");
    }

    string token = GenerateJwtToken(user);
    return LoginResult.Success(token);
  }

  private string GenerateJwtToken(User user)
  {
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
      _configuration["Jwt:Audience"],
      claims,
      expires: DateTime.UtcNow.AddDays(1),
      signingCredentials: credentials);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
