namespace Intern_Budgethold.Features.WalletManagement.Responses;

public class GetWalletResponse
{
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}
