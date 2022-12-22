using MedWorking.Core.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using KeyNotFoundException = MedWorking.Core.Common.Exceptions.KeyNotFoundException;
using NotImplementedException = MedWorking.Core.Common.Exceptions.NotImplementedException;
using UnauthorizedAccessException = MedWorking.Core.Common.Exceptions.UnauthorizedAccessException;

namespace MedWorking.Core.Common.CustomExceptionMiddleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionMiddleware> logger)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex,logger);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ExceptionMiddleware> logger)
    {
        HttpStatusCode statusCode;
        var stackTrace = string.Empty;
        string message = "";

        var exceptionType = ex.GetType();

        logger.LogError(ex.StackTrace!.ToString());

        if (exceptionType == typeof(BadRequestException))
        {
            message = ex.Message;
            statusCode = HttpStatusCode.BadRequest;
            stackTrace = ex.StackTrace;
        }
        else if(exceptionType == typeof(NotFoundException))
        {
            message = ex.Message;
            statusCode = HttpStatusCode.NotFound;
            stackTrace = ex.StackTrace;
        }
        else if (exceptionType == typeof(NotImplementedException))
        {
            message = ex.Message;
            statusCode = HttpStatusCode.NotImplemented;
            stackTrace = ex.StackTrace;
        }
        else if (exceptionType == typeof(KeyNotFoundException))
        {
            message = ex.Message;
            statusCode = HttpStatusCode.NotFound;
            stackTrace = ex.StackTrace;
        }
        else if (exceptionType == typeof(UnauthorizedAccessException))
        {
            message = ex.Message;
            statusCode = HttpStatusCode.Unauthorized;
            stackTrace = ex.StackTrace;
        }
        else
        {
            message = ex.Message;
            statusCode = HttpStatusCode.InternalServerError;
            stackTrace = ex.StackTrace;
        }

        var exceptionResult = JsonSerializer.Serialize(new  { error = message, stackTrace });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(exceptionResult);
    }
}
