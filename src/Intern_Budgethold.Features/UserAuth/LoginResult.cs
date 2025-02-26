namespace Intern_Budgethold.Features.UserAuth;

public class LoginResult
{
  public bool IsSuccess { get; private set; }
  public string Token { get; private set; } = string.Empty;
  public string ErrorMessage { get; private set; } = string.Empty;

  public static LoginResult Success(string token) =>
    new LoginResult { IsSuccess = true, Token = token };

  public static LoginResult Failure(string errorMessage) =>
    new LoginResult { IsSuccess = false, ErrorMessage = errorMessage };
}
