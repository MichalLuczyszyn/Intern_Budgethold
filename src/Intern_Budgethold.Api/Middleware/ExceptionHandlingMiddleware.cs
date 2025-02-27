using Microsoft.AspNetCore.Mvc;
using Intern_Budgethold.Core.Exceptions;
namespace Intern_Budgethold.Api.Middleware;

public class ExceptionHandlingMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionHandlingMiddleware> _logger;

  public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (ValidationResultException ex)
    {
      _logger.LogWarning(ex, "Validation result exception occurred.");
      await HandleValidationResultExceptionAsync(context, ex);
    }
    catch (BusinessException ex)
    {
      _logger.LogWarning(ex, "Business exception occurred.");
      await HandleBusinessExceptionAsync(context, ex);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An unhandled exception occurred.");
      await HandleExceptionAsync(context, ex);
    }
  }

  private static async Task HandleBusinessExceptionAsync(HttpContext context, BusinessException ex)
  {
    var exceptionDetails = ex switch
    {
      NotFoundException _ => (StatusCodes.Status404NotFound, "Resource not found"),
      _ => (StatusCodes.Status422UnprocessableEntity, "Business rule violation")
    };

    var statusCode = exceptionDetails.Item1;
    var title = exceptionDetails.Item2;

    var problemDetails = new ProblemDetails
    {
      Status = statusCode,
      Title = title,
      Detail = ex.Message
    };

    IResult result = Results.Problem(
      detail: problemDetails.Detail,
      statusCode: problemDetails.Status,
      title: problemDetails.Title);

    await result.ExecuteAsync(context);
  }

  private static async Task HandleValidationResultExceptionAsync(HttpContext context, ValidationResultException ex)
  {
    IResult result = Results.ValidationProblem(ex.Errors);

    await result.ExecuteAsync(context);
  }

  private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
  {
    var problemDetails = new ProblemDetails
    {
      Status = StatusCodes.Status500InternalServerError,
      Title = "An unexpected error occurred.",
      Detail = "An unexpected error occurred. Please try again later."
    };

    IResult result = Results.Problem(
        detail: problemDetails.Detail,
        statusCode: problemDetails.Status,
        title: problemDetails.Title);

    await result.ExecuteAsync(context);
  }
}
