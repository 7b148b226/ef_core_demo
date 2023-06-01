using System.Net;
using System.Net.Mime;
using ef_core_7_with_.net_7.Extensions;

namespace ef_core_7_with_.net_7.Middleware;

internal sealed class ExceptionHandler
{
    private RequestDelegate Next { get; }

    private ILogger Logger { get; }

    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        Next = next;
        Logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            Logger.LogInformation("_request");
            await Next(context);
            Logger.LogInformation($"_response: {context.Response.StatusCode}");
        }
        catch (Exception ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var dto = new
            {
                Errors = new Dictionary<string, IEnumerable<string>>
                {
                    {"error", new[] {ex.Message, }},
                },
            };
            await context.Response.WriteAsync(dto.ToJson());
            Logger.LogError(ex.Message);
        }
    }
}
