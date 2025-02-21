using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        IHttpContextAccessor contextAccessor,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _contextAccessor = contextAccessor;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await LogException(context, exception);
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task LogException(HttpContext context, Exception exception)
    {
        var logDetail = new
        {
            ExceptionMessage = exception.Message,
            StackTrace = exception.StackTrace,
            Path = context.Request.Path,
            Method = context.Request.Method,
            Time = DateTime.UtcNow
        };

        _logger.LogError("{@LogDetail}", logDetail);
        return Task.CompletedTask;
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var httpExceptionHandler = new HttpExceptionHandler
        {
            Response = context.Response
        };

        return httpExceptionHandler.HandleExceptionAsync(exception);
    }
} 