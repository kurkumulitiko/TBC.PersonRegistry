using System.Globalization;

namespace TBC.PersonRegistry.API.Extensions.Middlewares;


/// <summary>
/// Localization middleware
/// </summary>
public class LocalizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LocalizationMiddleware> _logger;



    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public LocalizationMiddleware(RequestDelegate next, ILogger<LocalizationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    /// <summary>
    /// InvokeAsync
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        var defaultCulture = "ka-GE";
        var supportedCultures = new[] { "ka-GE", "en-US"};

        string? requestedCulture = context.Request.Headers["Accept-Language"].FirstOrDefault();

        if (!string.IsNullOrEmpty(requestedCulture) && supportedCultures.Contains(requestedCulture))
        {
            var culture = new CultureInfo(requestedCulture);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            _logger.LogInformation("Culture set from Accept-Language: {Culture}", requestedCulture);
        }
        else
        {
            var culture = new CultureInfo(defaultCulture);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            _logger.LogInformation("Default culture used: {Culture}", defaultCulture);
        }

        await _next(context).ConfigureAwait(false);
    }
}
