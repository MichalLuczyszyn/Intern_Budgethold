using FluentValidation;

namespace Intern_Budgethold.Features.WalletManagement.Validators;

public class UpdateWalletCommandValidator : AbstractValidator<UpdateWalletCommand>
{
  public UpdateWalletCommandValidator()
  {
    RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
  }
}
