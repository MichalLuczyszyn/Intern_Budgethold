namespace Intern_Budgethold.Features.WalletManagment;

public class Wallet
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public decimal Balance { get; set; } = 0;
  public Guid CreatedByUserId { get; set; }
  public DateTime CreatedAt { get; set; }
  public uint MaxUsers { get; set; } = 2;
}
