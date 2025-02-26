namespace Intern_Budgethold.Features.WalletManagement;

public class Wallet
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public Guid CreatedByUserId { get; set; }
  public DateTime CreatedAt { get; set; }
  public uint MaxUsers { get; set; } = 2;
  public bool IsDeleted { get; set; } = false;
}
