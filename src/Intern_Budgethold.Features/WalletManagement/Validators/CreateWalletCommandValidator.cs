using FluentValidation;

namespace Intern_Budgethold.Features.WalletManagement.Validators;

public class CreateWalletCommandValidator : AbstractValidator<CreateWalletCommand>
{
  public CreateWalletCommandValidator()
  {
    RuleFor(x => x.Name).NotEmpty()
    .WithMessage("Wallet name is required.").MaximumLength(100);
  }
}
