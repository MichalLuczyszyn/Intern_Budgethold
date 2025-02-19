namespace Intern_Budgethold.Features.ReportManagement;

public class ReportDto
{
  public Guid WalletId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public decimal Balance { get; set; }
  public decimal TotalIncome { get; set; }
  public decimal TotalExpense { get; set; }
  public DateTime GeneratedAt { get; set; }
  public Guid GeneratedByUserId { get; set; }
}
