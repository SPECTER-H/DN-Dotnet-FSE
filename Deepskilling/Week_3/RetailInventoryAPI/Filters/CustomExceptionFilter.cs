using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RetailInventoryAPI.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomExceptionFilter : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var logDirectory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Logs");

        Directory.CreateDirectory(logDirectory);

        var logPath = Path.Combine(
            logDirectory,
            "exceptions.log");

        var logEntry =
            $"{DateTime.UtcNow:O}{Environment.NewLine}" +
            $"{context.Exception}{Environment.NewLine}" +
            $"{new string('-', 60)}{Environment.NewLine}";

        File.AppendAllText(logPath, logEntry);

        context.Result = new ObjectResult(new
        {
            Message = "An unexpected error occurred.",
            Detail = context.Exception.Message
        })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}