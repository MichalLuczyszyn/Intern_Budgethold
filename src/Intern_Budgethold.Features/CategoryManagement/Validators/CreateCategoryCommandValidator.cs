using FluentValidation;

namespace Intern_Budgethold.Features.CategoryManagement.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
  public CreateCategoryCommandValidator()
  {
    RuleFor(x => x.Name).NotEmpty().MaximumLength(100);

    RuleFor(x => x.Type).IsInEnum();
  }
}
