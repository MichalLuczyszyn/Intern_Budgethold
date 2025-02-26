using FluentValidation;
namespace Intern_Budgethold.Features.UserAuth.Validators;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
  {
    public RegisterUserCommandValidator()
    {
      RuleFor(x => x.Email).NotEmpty().EmailAddress();
      RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(30);
      RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
      RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
    }
  }
