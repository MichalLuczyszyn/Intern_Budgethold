namespace Intern_Budgethold.Features.Services;

public interface IPasswordHasher
{
  string HashPassword(string password);
  bool VerifyPassword(string password, string hashedPassword);
}

public class PasswordHasher : IPasswordHasher
{
  private readonly int _workFactor;

  public PasswordHasher(int workFactor = 12)
  {
    _workFactor = workFactor;
  }

  public string HashPassword(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
  }

  public bool VerifyPassword(string password, string hashedPassword)
  {
    try
    {
      return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
    catch (BCrypt.Net.SaltParseException)
    {
      return false;
    }
    catch (Exception)
    {
      return false;
    }
  }
}
