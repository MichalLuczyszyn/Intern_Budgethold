using Intern_Budgethold.Core.Enums;

namespace Intern_Budgethold.Features.TransactionManagment;

public class Transaction
{
  public Guid Id { get; set; }
  public Guid WalletId { get; set; }
  public Guid CreatedByUserId { get; set; }
  public decimal Amount { get; set; }
  public Currency Currency { get; set; } = Currency.PLN;
  public TransactionType Type { get; set; }
  public ExpenseCategory? ExpenseCategory { get; set; }
  public IncomeCategory? IncomeCategory { get; set; }
  public string? Description { get; set; }
  public DateTime Date { get; set; }
  public DateTime CreatedAt { get; set; }
  public bool IsDeleted { get; set; } = false;
  public DateTime? DeletedAt { get; set; }
  public Guid? DeletedByUserId { get; set; }
}
