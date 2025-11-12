using FluentValidation;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TBC.PersonRegistry.Application.Exceptions;

namespace TBC.PersonRegistry.API.Extensions.Middlewares;


/// <summary>
/// Exception Handler Middleware
/// </summary>
public class ExceptionHandler
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandler> logger;



    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        this.next = next;
        this.logger = logger;
    }


    /// <summary>
    /// InvokeAsync
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await Handler(context, ex);
        }
    }
    private async Task Handler(HttpContext context, Exception exception)
    {
        string titleText = "Internal Server Error.";
        var statusCode = (int)HttpStatusCode.InternalServerError;
        var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

        switch (exception)
        {

            case ApiValidationException e:
                logger.LogWarning(exception.Message);
                statusCode = (int)e.StatusCode;
                break;


            case ValidationException _:
                logger.LogWarning(exception.Message);
                statusCode = (int)HttpStatusCode.BadRequest;
                break;

            case OperationCanceledException:
                logger.LogWarning(exception, nameof(OperationCanceledException));
                exception = new Exception("Operation Is Canceled.");
                titleText = "Operation Is Canceled.";
                break;

            case Exception _:
                logger.LogError(exception, exception.Message);
                statusCode = (int)HttpStatusCode.InternalServerError;
                titleText = "Internal Server Error.";
                break;

        }

        var response = new
        {
            statusCode,
            traceId,
            titleText,
            exception = new
            {
                exceptionType = exception.GetType().Name,
                exception.Message,
            }
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var json = JsonConvert.SerializeObject(response,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });

        await context.Response.WriteAsync(json);

    }
}
