using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.ReportManagement;

public class Report
{
  public Guid Id { get; set; }
  public Guid WalletId { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public decimal Balance { get; set; }
  public decimal TotalIncome { get; set; }
  public decimal TotalExpense { get; set; }
  public Dictionary<ExpenseCategory, decimal> ExpensesByCategory { get; set; } = new();
  public Dictionary<IncomeCategory, decimal> IncomesByCategory { get; set; } = new();
  public DateTime GeneratedAt { get; set; }
  public Guid GeneratedByUserId { get; set; }
}
