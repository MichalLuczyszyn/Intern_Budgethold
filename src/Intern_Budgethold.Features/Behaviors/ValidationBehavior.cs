using FluentValidation;
using MediatR;
using FluentValidation.Results;

namespace Intern_Budgethold.Features.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
{
  private readonly IEnumerable<IValidator<TRequest>> _validators;

  public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
  {
    _validators = validators;
  }

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
  {
    if (!_validators.Any())
      return await next();

    var context = new ValidationContext<TRequest>(request);

    var validationResults = await Task.WhenAll(
      _validators.Select(v => v.ValidateAsync(context, ct))
    );

    var failures = validationResults
      .Where(r => r.Errors.Any())
      .SelectMany(r => r.Errors)
      .ToList();

    if (failures.Any())
    {
      var validationResult = new ValidationResult(failures);

      throw new ValidationException(validationResult.Errors);
    }
    return await next();
  }
}
