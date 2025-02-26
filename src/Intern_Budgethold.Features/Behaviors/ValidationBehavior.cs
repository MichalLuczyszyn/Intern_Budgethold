using FluentValidation;
using MediatR;
using FluentValidation.Results;
using Intern_Budgethold.Core.Exceptions;

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
      .SelectMany(r => r.Errors)
      .ToList();

    if (failures.Any())
    {
      var errorsDictionary = failures.GroupBy(
        x => x.PropertyName,
        x => x.ErrorMessage,
        (propertyName, errorMessages) => new
        {
          Key = propertyName,
          Values = errorMessages.Distinct().ToArray()
        })
        .ToDictionary(x => x.Key, x => x.Values);

      throw new ValidationResultException(errorsDictionary);
    }
    return await next();
  }
}
