using FluentValidation;

namespace Intern_Budgethold.Features.CategoryManagement;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
  public UpdateCategoryCommandValidator()
  {
    RuleFor(x => x.Name.Value).NotEmpty().MaximumLength(50);
    RuleFor(x => x.Description).MaximumLength(200);
    RuleFor(x => x.Type).NotEmpty().IsInEnum();
  }
}
