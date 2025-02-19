namespace Intern_Budgethold.Features.WalletManagment;

public class WalletUser
{
  public Guid UserId { get; set; }
  public Guid WalletId { get; set; }
  public DateTime JoinedAt { get; set; }
}
