using Intern_Budgethold.Features.WalletManagement.Exceptions;

namespace Intern_Budgethold.Features.WalletManagement;

public class Wallet
{
  public Guid Id { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public Guid CreatedByUserId { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public uint MaxUsers { get; private set; } = 2;
  public bool IsDeleted { get; private set; } = false;
  private readonly List<WalletUser> _users = new();
  public IReadOnlyCollection<WalletUser> Users =>
    _users.AsReadOnly();

  private Wallet() {}

  public static Wallet Create(
    string name,
    Guid createdByUserId,
    DateTime createdAt
  )
  {
    return new Wallet
    {
      Id = Guid.NewGuid(),
      Name = name,
      CreatedByUserId = createdByUserId,
      CreatedAt = createdAt,
    };
  }

  public void UpdateName(string newName)
  {
    Name = newName;
  }

  public void SoftDelete()
  {
    IsDeleted = true;
  }

  public void AddUser(Guid userId)
  {
    if (_users.Count >= MaxUsers)
      throw new MaxUsersExceededException(MaxUsers);

    if (_users.Any(u => u.UserId == userId))
    {
      throw new UserAlreadyInWalletException();
    }
    _users.Add(new WalletUser(userId, this.Id));
  }
}
