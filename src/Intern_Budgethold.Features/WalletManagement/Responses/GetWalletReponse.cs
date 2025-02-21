namespace Intern_Budgethold.Features.WalletManagement.Responses;

public class GetWalletResponse
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public DateTime CreatedAt { get; set; }
}
