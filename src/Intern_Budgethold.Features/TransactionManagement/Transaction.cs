using Intern_Budgethold.Core.Enums;
using Intern_Budgethold.Features.CategoryManagement;

namespace Intern_Budgethold.Features.TransactionManagement;

public class Transaction
{
  public Guid Id { get; set; }
  public Guid WalletId { get; set; }
  public Guid CreatedByUserId { get; set; }
  public decimal Amount { get; set; }
  public Currency Currency { get; set; } = Currency.PLN;
  public Guid CategoryId { get; set; }
  public Category Category { get; set; }
  public string? Description { get; set; }
  public DateTime Date { get; set; }
  public DateTime CreatedAt { get; set; }
  public bool IsDeleted { get; set; } = false;
}
