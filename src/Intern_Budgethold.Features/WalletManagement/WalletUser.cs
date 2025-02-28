namespace Intern_Budgethold.Features.WalletManagement;

public class WalletUser
{
  public Guid UserId { get; set; }
  public Guid WalletId { get; set; }
  public DateTime JoinedAt { get; set; }
  public bool IsDeleted { get; set; } = false;

  private WalletUser() {}

  public WalletUser(Guid userId, Guid walletId)
  {
    UserId = userId;
    WalletId = walletId;
    JoinedAt = DateTime.UtcNow;
  }
}
