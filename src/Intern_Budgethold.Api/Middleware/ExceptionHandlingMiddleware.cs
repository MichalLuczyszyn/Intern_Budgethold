using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FluentValidation;
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
    catch (ValidationException ex)
    {
      _logger.LogWarning(ex, "Validation exception occurred.");
      await HandleValidationExceptionAsync(context, ex);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "An unhandled exception occurred.");
      await HandleExceptionAsync(context, ex);
    }
  }

  private static async Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
  {
    var errors = ex.Errors
        .GroupBy(e => e.PropertyName)
        .ToDictionary(
            g => g.Key,
            g => g.Select(e => e.ErrorMessage).ToArray()
        );

    var problemDetails = new ValidationProblemDetails(errors)
    {
      Status = StatusCodes.Status400BadRequest,
      Title = "One or more validation errors occurred.",
    };

    context.Response.StatusCode = StatusCodes.Status400BadRequest;
    context.Response.ContentType = "application/problem+json";
    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
  }

  private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
  {
    var problemDetails = new ProblemDetails
    {
      Status = StatusCodes.Status500InternalServerError,
      Title = "An unexpected error occurred.",
      Detail = "An unexpected error occurred."
    };

    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Response.ContentType = "application/problem+json";
    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
  }
}
