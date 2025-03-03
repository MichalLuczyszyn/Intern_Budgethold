using FluentValidation;

namespace Intern_Budgethold.Features.CategoryManagement.Validators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
  public CreateCategoryCommandValidator()
  {
    RuleFor(x => x.Name.Value).NotEmpty().MaximumLength(50);
    RuleFor(x => x.Description).MaximumLength(200);
    RuleFor(x => x.Type).IsInEnum();
  }
}
